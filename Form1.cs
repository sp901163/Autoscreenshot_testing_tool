using System;//a core library for fundamental types and basic programming functionalities.
using System.Diagnostics;//a library for interacting with system processes, performance counters, event logs, and debugging functionalities.
using System.IO;//a library for input and output operations, such as file and directory handling.
using System.Threading;//a library for managing threads, synchronization, and concurrent programming.
using System.Windows.Forms;//a library for creating Windows-based applications with graphical user interfaces.
using Microsoft.Office.Interop.Word;// a library for automating Microsoft Word application, which allows creating, editing, and formatting Word documents programmatically.
                                    // Microsoft.Office.Interop.Excel;//Microsoft.Office.Interop.PowerPoint;
using System.Drawing;//a library that provides classes for creating, manipulating, and rendering images and graphical objects.
using Document = Microsoft.Office.Interop.Word.Document;
using System.Runtime.InteropServices;//a library that enables interoperability between managed code and unmanaged code, such as calling functions from native code, accessing COM components, and working with memory.
using Application = Microsoft.Office.Interop.Word.Application;
using System.Drawing.Imaging;//a library for working with images and encoding/decoding image files.
using System.Collections.Generic;//a library for generic collection classes and interfaces, such as lists, dictionaries, and queues.
using System.Text;//a library for working with character encodings and string manipulation.
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//Note:1]NuGet is library or package manager for C# and .Net framework.
//     2]This  Application built using C# and .Net[4.5] so it can run on windows 7 and above version.

namespace Autoscreenshot_testing_tooll
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")] //DLL mean Dynamic link library, we generally use/import this dll when some function defined in .Net 
        //won't work properly then only we use dll. 
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        static int GetWindowProcessId(IntPtr hWnd)
        {
            int processId;
            GetWindowThreadProcessId(hWnd, out processId);
            return processId;
        }

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        bool ismouseClicked; //working as global variable 
        bool isactiveWindow;//working as global variable 
        bool allAppsVisible;//working as global variable
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        List<string> processNames = new List<string>(); //{ "notepad", "chrome", "sqldeveloper64W" }; //select application to capture screenshot
                                                        // process name use #tasklist /v /fi "ImageName eq sqldeveloper.exe" //chrome.exe[put only chrome don't use .exe with name]

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        public Form1()
        {
            InitializeComponent();
            listBox1.DoubleClick += listBox1_DoubleClick;//Add listBox1 item into listView1
            listView1.DoubleClick += listView1_DoubleClick;//Remove listBox1 item from listView1
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create the AutoScreen_Sharad_P folder if it doesn't exist
            string directoryPath = @"C:\AutoScreen_Sharad_P\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Debug.WriteLine("Directory has created!!");
            }

        }

        private void start_button_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Auto Screenshot Started!!");
            /*In a Windows Forms application using C#, the main thread is responsible for processing user interface (UI) events such as button clicks, 
             * This means that if a method is executing on the main thread and it takes a long time to complete, 
             * the UI will become unresponsive until the method returns back to main thread.To avoid this issue and keep the UI responsive, 
             * we use asynchronous programming techniques such as running the method on a separate thread  using asynchronous method mentioned as below 
             * System.Threading.Tasks.Task.Run(() 
            */
            System.Threading.Tasks.Task.Run(() =>  //asynchronous programming techniques in C#
            {
                while (true)
                {
                    IsInputDetected(); //checking mouse input is detected or not i.e mouse is clicked or not
                    Check_Active_Window(); //checking window is active or not
                                           // IsApplicationsLoadedAndVisible(processNames); //checking wheather active window is accessable and visible 
                                           //if (ismouseClicked == true && isactiveWindow == true)
                    CreateDocument();
                }
            }
            );
        }


        public void IsInputDetected() //check mouse is clicked or not 
        {
            ismouseClicked = false;
            while (!ismouseClicked)
            {
                POINT cursorPos;
                GetCursorPos(out cursorPos);

                if ((GetAsyncKeyState(0x01) & 0x8000) != 0) // 0x01 is the left mouse button
                {
                    ismouseClicked = true;
                }

            }
        }
        private void Check_Active_Window() //check application window/screen to capture from List<string> processNames = new List<string>(); 
        {
            isactiveWindow = false;
            IntPtr hWnd = GetForegroundWindow();
            StringBuilder windowTitle = new StringBuilder(256);
            GetWindowText(hWnd, windowTitle, windowTitle.Capacity);
            Process activeProcess = Process.GetProcessById(GetWindowProcessId(hWnd));//activeProcess is variable which hold active process/screen id and campare with processNames 

            if (processNames.Contains(activeProcess.ProcessName)) //processNames is List<string>() which hold name of application to capture the screenshot.
            {
                Debug.WriteLine("Application Found!!");
                isactiveWindow = true;
            }
            else
            {
                Debug.WriteLine("Application not Found!!");
                isactiveWindow = false;
            }
        }
        private void CreateDocument()
        {
            // Create a new Word application
            Application wordApp = new Application();

            // Hide the application window
            wordApp.Visible = false;

            // Create a new document
            Document document = wordApp.Documents.Add();

            foreach (Section section in document.Sections)
            {
                //header come here
                Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                headerRange.Font.ColorIndex = WdColorIndex.wdRed;
                headerRange.Font.Size = 8;
                headerRange.Text = "Created by Sharad_Pawar[ACES_Delivery]";
            }

            foreach (Section wordSection in document.Sections)
            {
                //footer come here 
                Range footerRange = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Font.ColorIndex = WdColorIndex.wdRed;
                footerRange.Font.Size = 8;
                footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                footerRange.Text = "S!";
            }

            // Save the document to the C:\ AutoScreen_Sharad_P
            string filename = $"C:\\ AutoScreen_Sharad_P\\{DateTime.Now:yyyy-MM-dd_HH-mm}.docx";
            document.SaveAs2(filename, WdSaveFormat.wdFormatDocumentDefault);
            int j = 0;
            while (j <= 6)
            {
                //  long fileSize = new FileInfo(filename).Length;//checkimg the file size if 20mb then create new doc file

                // Check if the file size is 20MB
                // bool is20MB = fileSize >= (20 * 1024 * 1024);
                //Debug.Write(is20MB);

                //   if (ismouseClicked == true && isactiveWindow == true)// && is20MB == false) // check file size as well 
                {

                    //Take Screenshot
                    Thread.Sleep(100);//1sec
                    Debug.WriteLine("own logs" + DateTime.Now);
                    Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width + 400, Screen.PrimaryScreen.Bounds.Height + 300);//defining screen width & height size. 
                    Graphics graphics = Graphics.FromImage(screenshot);
                    graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);


                    // Get the mouse position
                    System.Drawing.Point mousePosition = Cursor.Position;

                    // Define the rectangle around the mouse click
                    System.Drawing.Rectangle mouseRectangle = new System.Drawing.Rectangle(mousePosition.X - 50, mousePosition.Y - 50, 50, 50);

                    // Draw a red rectangle around the mouse click
                    Pen redPen = new Pen(Color.Red, 3);
                    graphics.DrawRectangle(redPen, mouseRectangle);

                    //Save screenshot in C:\AutoScreen_Sharad_P\
                    string filePath = @"C:\AutoScreen_Sharad_P\screenshot.png";
                    screenshot.Save(filePath, ImageFormat.Png);


                    //Pickup screenshot from C:AutoScreen_Sharad_P\ and Save Screenshot into Doc file
                    InlineShape shape = document.InlineShapes.AddPicture(FileName: "C:\\AutoScreen_Sharad_P\\screenshot.Png",
                                                                         LinkToFile: false, SaveWithDocument: true, Range: document.Range());

                    // Clean up resources
                    graphics.Dispose();
                    screenshot.Dispose();

                    j++;
                }

            }


            // Close the document and the application
            document.Close();
            wordApp.Quit();

            // Release the COM objects of document
            ReleaseObject(document);
            ReleaseObject(wordApp);

            Debug.WriteLine("Document Created Successfully!!");
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
            }
            catch
            {
                // Ignore any errors that occur while releasing the object
            }
            finally
            {
                obj = null;
            }
        }

        private void end_button_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("End Button is Clicked!");
            MessageBox.Show("Auto Screenshot Stopped!!");
            System.Windows.Forms.Application.Exit(); // stop the auto screenshot capturing process
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If facing issue,Contact to Sharad Pawar (AT&T_AEG) OR Atit Thakur (AT&T_AEG) OR Vikas Saini", "Message from Sharad Pawar (AT&T_AEG)");
            // Clear any previous items in the list box

        }

        private void Check_button_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listView1.Items.Clear();
            // Get the current process
            Process currentProcess = Process.GetCurrentProcess();

            // Get all processes running on the local machine
            Process[] allProcesses = Process.GetProcesses();


            foreach (Process process in allProcesses)
            {
                // Check if the process is not the current process and has a main window title
                if (process.Id != currentProcess.Id && !string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    // Add the process name and main window title to the list box
                    listBox1.Items.Add(process.ProcessName);//process.MainWindowTitle//process.ProcessName//process.Id
                }
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // Get the selected item from the ListBox
            string selectedItem = listBox1.SelectedItem.ToString();

            // Add a new item to the ListView with the selected item's text
            ListViewItem newItem = new ListViewItem(selectedItem);
            // newItem.SubItems.Add("Description of " + selectedItem);
            listView1.Items.Add(newItem);
            string selectedText = newItem.Text;
            processNames.Add(selectedText);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // Get the selected item from the ListView
            ListViewItem selectedItem = listView1.SelectedItems[0];

            // Remove the selected item from the ListView
            listView1.Items.Remove(selectedItem);
            string selectedText = selectedItem.Text;
            processNames.Remove(selectedText);
        }

        public static bool IsApplicationsLoadedAndVisible(List<string> windowTitles)
        {

            bool allAppsVisible = false;

            foreach (string appName in windowTitles)
            {
                Process[] processes = Process.GetProcessesByName(appName);

                if (processes.Length == 0)
                {
                    // Application is not running
                    allAppsVisible = false;
                    break;
                }

                bool isAppVisible = false;
                foreach (Process process in processes)
                {
                    if (process.MainWindowHandle != IntPtr.Zero && process.MainWindowTitle.Length > 0)
                    {
                        // Application is running and visible
                        isAppVisible = true;
                        break;
                    }
                }

                if (!isAppVisible)
                {
                    // Application is running but not visible
                    allAppsVisible = false;
                    break;
                }
            }

            if (allAppsVisible)
            {
                Debug.WriteLine("All applications are visible and accessible.");
                return true;
            }
            else
            {
                Debug.WriteLine("Some applications are not visible or not running.");
                return false;
            }
        }
    }

}