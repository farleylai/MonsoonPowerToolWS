//CPPClient.cpp
//Demos use of the PowerTool COM Interface

#include "stdafx.h"
#include <atlbase.h>
#include <atlsafe.h>
#include <windows.h>
#import "C:\powermonitor\PowerTool\bin\Release\PowerTool.tlb"// fix this to match your current location!!

using namespace PowerTool;

int _tmain(int argc, _TCHAR* argv[])
{
	IAutomation *pAutomation = NULL;
	CComPtr<IAutomation> autoPtr;

	//initialize the com library
	::CoInitialize(NULL);

	//get the instance
	HRESULT hr = autoPtr.CoCreateInstance(_T("PowerTool.Automation"));
	if (SUCCEEDED(hr)){
		// launch the powertool GUI application
		printf("\nStarting Powertool application in automation mode.");
		BOOL running =autoPtr->OpenApplication(false,30);
		if (running){
			//get available devices
			
			CComSafeArray<USHORT> *serialNumbers;
			serialNumbers = new CComSafeArray<USHORT>(1);

			UINT deviceCount=autoPtr->EnumerateDevices((SAFEARRAY**) serialNumbers);
			if (deviceCount > 0){
				printf("\n%u Devices found",deviceCount);
				//connect to the first one
				USHORT serialno=serialNumbers->GetAt(0);			
				if (autoPtr->ConnectDevice(serialno)){
					printf("\nSuccessfully connected to device with serial no: %u",serialno);
					//make sure we are visible
					autoPtr->PutVisible(true);
					//Specify MAIN channel
					autoPtr->PutCaptureMainCurrent(true);
					//specify usbpassthroughmode
					autoPtr->PutUsbPassthroughMode(UsbPassthroughMode_Auto);

					//specify VOUT
					autoPtr->PutMainOutputVoltageSetting((float)4.2);
					//enable VOUT
					autoPtr->PutEnableMainOutputVoltage(true);
					
					//start sampling
					printf("\nStarting Sampling\n");
					autoPtr->StartSampling(10);
					
					Sleep(5000);// this is just to let us sample for a few seconds in this example. 
								// In practice, you would want to do your main work here, use triggers to control when to stop sampling, etc

					//stop sampling manually
					printf("\nStoppingSampling\n");
					autoPtr->StopSampling(10);

					//disable vout
					autoPtr->PutEnableMainOutputVoltage(false);
					
					//write out data somewhere
					_bstr_t filename="c:\\temp\\tempdata.pt4"; //must have .pt4 in the filename (pick a location you have permissions to write to)

					printf("\nAttempting to save data to: %s",(LPCSTR)filename);
					try{
						BOOL datasaved =autoPtr->SaveFile(filename,true,true);
						if (datasaved){
							printf("\nSuccessfully saved data to: %s",(LPCSTR)filename);
						}
						else{
							printf("\nUnable to save data to: %s",(LPCSTR)filename);
						}
					}catch (...){
						printf("\n!Exception! Are you sure you have permission to write to the specified location?\nUnable to save data to :%s",(LPCSTR)filename);
					}
			
					//close the device
					autoPtr->DisconnectDevice();

					//close the powertool application
					autoPtr->CloseApplication(false,30);
				}
				else{
					printf("\nFailed to connect to device with serial number: %u",serialno);
					autoPtr->CloseApplication(false,30);
				}
			}
			else{
				printf("\nNo devices found");
				autoPtr->CloseApplication(false,30);
			}
		}
		else {
			printf("\nUnable to start Powertool application.");
		}
	}
	else {
		printf("\nCould not instantiate the PowerTool Object. -%x",hr);
		printf("\nCheck that the PowerTool.exe has been registered");
	}

	//release COM object when done
	if (pAutomation)
		pAutomation->Release();
	
	//uninitialize the com library
	CoUninitialize();
	
	return 0;

}


