import java.io.File;
import java.math.BigInteger;
import javax.xml.ws.Holder;
import com.microsoft.schemas._2003._10.serialization.arrays.*;
import org.datacontract.schemas._2004._07.powertool.*;
import org.tempuri.*;

import org.junit.*;
import org.junit.rules.*;
import static org.junit.Assert.*;
import static java.math.BigInteger.*;

public class PowerToolServiceTest {
    @Rule
    public TestName INFO = new TestName();
    private IPowerToolService pt;

    @Before
    public void setUp() {
        pt = new PowerToolService().getBasicHttpBindingIPowerToolService();
    }

    @Test
    public void testPowerToolServiceSampling() throws Exception {
        // Single use only, clear any previous unfinished processing
        if(pt.getSampleIsRunning()) 
            pt.stopSamplingF(true);
        if(pt.getDeviceIsConnected())
            assertTrue(pt.disconnectDevice());
        if(pt.getApplicationIsOpen())
            assertTrue(pt.closeApplicationF(false, true));
        if(pt.getDeviceCount() == 0) {
            // FIXME if resetPowerMonitor returns false, reboot the power monitor
            throw new RuntimeException("No Monsoon power meter is plugged in");
            //assertTrue(pt.resetPowerMonitor());
        }

        // Enumerate devices, assume only one attached
        Holder<Long> count = new Holder<>();
        Holder<ArrayOfunsignedShort> serials = new Holder<>();
        pt.enumerateDevices(count, serials);
	while(count.value.longValue() == 0) {
	    System.out.println("No Monsoon power monitor is enumerated, retry...");
	    Thread.sleep(1000);
            pt.enumerateDevices(count, serials);
        }
        System.out.printf("Found connected Monsoon monitor of serial %d\n", serials.value.getUnsignedShort().get(0).intValue());

        // Open application, connect device and set parameters for sampling the main channel
        // No need to set trigger setting and it works better when visible
        assertTrue(pt.openApplicationFG(false, true, true));
        assertTrue(pt.connectDevice(serials.value.getUnsignedShort().get(0).intValue()));
        pt.setUsbPassthroughMode(UsbPassthroughMode.AUTO);
        pt.setEnableMainOutputVoltage(true);
        pt.setMainOutputVoltageSetting(3.7f);
        pt.setBatterySize(3220L);

        // start/stop sampling and print progress every second
        assertTrue(pt.startSamplingF(true));
        for (int i = 1; i <= 2; i++) {
            assertTrue(pt.getDeviceIsConnected());
            assertTrue(pt.getSampleIsRunning());
            Thread.sleep(2 * 1000);
            SelectionData sd = pt.getSelectionData();
            System.out.printf("Instant main channel: samples=%d, current=%f.2, voltage=%f.2\n", 
                                sd.getSampleCount(), sd.getInstMainCurrent(), sd.getInstMainVoltage());
        }
        assertTrue(pt.stopSamplingF(true));

        // save samples in pt5 and csv on the Windows machine
        assertTrue(pt.getHasData());
        //String filename = "\\\\vmware-host\\Shared Folders\\Downloads\\pt";
        String filename = "C:\\Users\\LaiFarley\\Downloads\\pt";
        assertTrue(pt.exportCSV(ZERO, pt.getTotalSampleCount().subtract(ONE), 1L, filename + ".csv", true, true));
        //assertTrue(pt.saveFile(filename + ".pt5", true, true));

        // disconnect and close
        assertTrue(pt.disconnectDevice());
        assertTrue(pt.closeApplicationF(false, true));
        assertEquals(ExitCode.SUCCESS, pt.getExitCode());
    }
}
