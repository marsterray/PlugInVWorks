using IWorksDriver;
using stdole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.MetadataServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PlugInBlueprint
{
    [System.Runtime.InteropServices.Guid("00000000-0000-0000-0000-000000000000"), ComVisible(true)]
    public class Class1 : IWorksDriver.IWorksDriver, IWorksDriver.IWorksDiags, IWorksDriver.CControllerClient
    {
        private IWorksDriver.CWorksController controllerInstance;

        public Meca500 Robot { get; set; }

        string IWorksDriver.IWorksDriver.GetMetaData(MetaDataType iDataType, string current_metadata)
        {


            XDocument metadata = new XDocument(

                new XDeclaration("1.0", "us-ascii", null),

                new XElement("Velocity11",

                    new XAttribute("file", "MetaData"),

                    new XElement("MetaData",

                        new XElement("Device",

                            new XAttribute("Description", "Communication Robot"),

                            new XAttribute("MiscAttributes", "0"),

                            new XAttribute("Name", "Communication"),

                            new XAttribute("PreferredTab", "Robotics"),

                            new XElement("Parameters",

                                new XElement("Parameter",

                                    new XAttribute("Name", "Motion Speed"),

                                    new XAttribute("Style", "1"),

                                    //new XAttribute("Type", "2"),

                                    new XAttribute("Value", "mm/s")

                                ),

                                new XElement("Parameter",

                                    new XAttribute("Name", "Rotation Speed"),

                                    new XAttribute("Style", "1"),

                                    //new XAttribute("Type", "2"),

                                    new XAttribute("Units", "deg/s")

                                )

                            ),

                            new XElement("Locations",

                                new XElement("Location",

                                    new XAttribute("Name", "Stage"),

                                    new XAttribute("Type", "1")

                                    )

                            ),

                            new XElement("StorageDimensions",

                                new XAttribute("DirectStorageAccess", "1")

                            )

                        ),

                        new XElement("Versions",

                            new XElement("Version",

                                new XAttribute("Author", "Terray Automation"),

                                new XAttribute("Date", "September 13, 2023"),

                                new XAttribute("Name", "Communication"),

                                new XAttribute("Version", "1.0.0")

                            )

                        ),

                        new XElement("Commands",

                            //new XElement("Command",

                            //    new XAttribute("Compiler", "0"),

                            //    new XAttribute("Description", "Messenger"),

                            //    new XAttribute("Editor", "2"),

                            //    new XAttribute("Name", "Messenger"),

                            //    new XElement("Parameters",

                            //        new XElement("Parameter",

                            //            new XAttribute("Name", "Messenger"),

                            //            new XAttribute("Style", "1"),

                            //           // new XAttribute("Type", "2"),

                            //            new XAttribute("Units", "None"),

                            //            new XAttribute("Value", "Connected")

                            //        )

                            //    )

                            //),
                            
                            new XElement("Command",

                                new XAttribute("Compiler", "0"),

                                new XAttribute("Description", "Deactivate the robot"),

                                new XAttribute("Editor", "2"),

                                new XAttribute("Name", "Deactivate"),

                                new XElement("Parameters",

                                    new XElement("Parameter",

                                        new XAttribute("Name", "Deactivate"),

                                        new XAttribute("Style", "1"),

                                        new XAttribute("Value", "NULL")

                                    )

                                )


                            ),

                            new XElement("Command",

                                new XAttribute("Compiler", "0"),

                                new XAttribute("Description", "Move the Robot to the WayPoint"),

                                new XAttribute("Editor", "2"),

                                new XAttribute("Name", "WayPoint"),

                                new XElement("Parameters",

                                    new XElement("Parameter",

                                        new XAttribute("Description", "Grab a Waypoint"),

                                        new XAttribute("Name", "WayPoint"),

                                        new XAttribute("Style", "0"),

                                        new XAttribute("Type", "3"),

                                        new XAttribute("Value", " xPos=\"240.4530\" yPos=\"149.4768\" zPos=\"202.2412\" alpha=\"-87.7197\" beta=\"58.7363\" gamma=\"-32.3439\" ")

                                   )
                                )
                            ),

                            new XElement("Command",

                                new XAttribute("Compiler", "0"),

                                new XAttribute("Description", "Deactivate the robot"),

                                new XAttribute("Editor", "2"),

                                new XAttribute("Name", "Deactivate"),

                                new XElement("Parameters",

                                    new XElement("Parameter",

                                        new XAttribute("Name", "Deactivate"),

                                        new XAttribute("Style", "1"),

                                        new XAttribute("Value", "NULL")

                                    )

                                )

                            ),
                            
                            new XElement("Command",

                                new XAttribute("Compiler", "0"),

                                new XAttribute("Description", "Homes the robot"),

                                new XAttribute("Editor", "2"),

                                new XAttribute("Name", "Home"),

                                new XElement("Parameters",

                                    new XElement("Parameter",

                                        new XAttribute("Name", "Home"),

                                        new XAttribute("Style", "1"),

                                        new XAttribute("Value", "NULL")

                                    )

                                )

                            ),

                            new XElement("Command",

                                new XAttribute("Compiler", "0"),

                                new XAttribute("Description", "Connects to the robot"),

                                new XAttribute("Editor", "2"),

                                new XAttribute("Name", "Connect"),

                                new XElement("Parameters",

                                    new XElement("Parameter",

                                        new XAttribute("Name", "Connect"),

                                        new XAttribute("Style", "1"),

                                        new XAttribute("Value", "NULL")

                                    )

                                )

                            ),

                            new XElement("Command",

                                new XAttribute("Compiler", "0"),

                                new XAttribute("Description", "Activates the robot"),

                                new XAttribute("Editor", "2"),

                                new XAttribute("Name", "Activate"),

                                new XElement("Parameters",

                                    new XElement("Parameter",

                                        new XAttribute("Name", "Activate"),

                                        new XAttribute("Style", "1"),

                                        new XAttribute("Value", "NULL")

                                )

                            )

                        ),

                        new XElement("Command",

                                new XAttribute("Compiler", "0"),

                                new XAttribute("Description", "Disconnects the Robot"),

                                new XAttribute("Editor", "2"),

                                new XAttribute("Name", "Disconnect"),

                                new XElement("Parameters",

                                    new XElement("Parameter",

                                        new XAttribute("Name", "Disconnect"),

                                        new XAttribute("Style", "1"),

                                        new XAttribute("Value", "NULL")

                                    )

                                )

                            )

                        )

                    )

                )

            );


            return metadata.Declaration.ToString() + metadata.ToString();

        }

        ReturnCode IWorksDriver.IWorksDriver.Initialize(string CommandXML)
        {
            Robot = new Meca500("192.168.0.100", 10000);
            Robot.ConnectRobot();
            Robot.ActivateRobot();
            Robot.HomeRobot();

            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        void IWorksDriver.IWorksDriver.Close()
        {
            // TODO
        }

        void IWorksDriver.IWorksDriver.ShowDiagsDialog(SecurityLevel iSecurity)
        {
            // TODO
        }

        void IWorksDriver.IWorksDriver.Abort(string ErrorContext)
        {
            // TODO
        }

        ReturnCode IWorksDriver.IWorksDriver.Ignore(string ErrorContext)
        {
            // Any way to ignore? Don't think so.
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        ReturnCode IWorksDriver.IWorksDriver.Retry(string ErrorContext)
        {
            // TODO
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        // MORE TESTING
        // private HttpClient client = new HttpClient();

        // TESTING 
        private async System.Threading.Tasks.Task PostRequestAsync(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(message);
                // await client.PostAsync("http://127.0.0.1:8000/items/", content);
                // await client.PostAsync("http://10.25.100.6:5050/items/", content);
                await client.PostAsync("http://10.200.50.24:5050/items/", content);
            }
        }

        ReturnCode IWorksDriver.IWorksDriver.Command(string CommandXML)
        {
            //XDocument xcommand = XDocument.Parse(CommandXML);
            //PostRequestAsync(CommandXML);
            //PostRequestAsync("Line 207 reached!");
            //string commandName = (string)xcommand.Descendants("Command").Attributes("Name").FirstOrDefault();
            //PostRequestAsync(commandName); 
            //PostRequestAsync("Line 209 reached!");

            //IWorksDriver.ReturnCode status = IWorksDriver.ReturnCode.RETURN_SUCCESS;
            //PostRequestAsync("Line 445 reached!");

            //switch (commandName)
            //{
            //    case "Messenger":
            //        PostRequestAsync("Line 217 reached!");
            //        break;
            //}

            //PostRequestAsync("Line 221 reached!");
            //return status;

            XDocument xcommand = XDocument.Parse(CommandXML);
            string commandName = (string)xcommand.Descendants("Command").Attributes("Name").FirstOrDefault();

            IWorksDriver.ReturnCode status = IWorksDriver.ReturnCode.RETURN_SUCCESS;

            switch (commandName)
            {
                case "Home":
                    Robot.HomeRobot();
                    break;
                case "Deactivate":
                    Robot.DeactivateRobot();
                    break;
                case "Disconnect":
                    Robot.DisconnectRobot();
                    break;
                case "Connect":
                    Robot.ConnectRobot();
                    break;
                case "Activate":
                    Robot.ActivateRobot();
                    break;
                case "WayPoint":
                    var parameterDescription = (string)xcommand.Descendants("Parameter")
                                                                .Attributes("Value")
                                                                .FirstOrDefault();
                    var coordinates = ParseCoordinates(parameterDescription);
                    // PostRequestAsync(coordinates.ToString());
                    Robot.MovePose(coordinates);
                    break;
            }
            return status;

        }

        private MecaCartesianCoordinate ParseCoordinates(string description)
        {
            var parts = description.Split(new[] { ' ', '=', '\"' }, StringSplitOptions.RemoveEmptyEntries);

            var coordinates = new MecaCartesianCoordinate();

            for (int i = 0; i < parts.Length; i++)
            {
                switch (parts[i])
                {
                    case "xPos":
                        coordinates.X = double.Parse(parts[i + 1]);
                        break;
                    case "yPos":
                        coordinates.Y = double.Parse(parts[i + 1]);
                        break;
                    case "zPos":
                        coordinates.Z = double.Parse(parts[i + 1]);
                        break;
                    case "alpha":
                        coordinates.Rx = double.Parse(parts[i + 1]);
                        break;
                    case "beta":
                        coordinates.Ry = double.Parse(parts[i + 1]);
                        break;
                    case "gamma":
                        coordinates.Rz = double.Parse(parts[i + 1]);
                        break;
                }
            }

            return coordinates;
        }

        ReturnCode IWorksDriver.IWorksDriver.MakeLocationAvailable(string LocationAvailableXML)
        {
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        bool IWorksDriver.IWorksDriver.IsLocationAvailable(string LocationAvailableXML)
        {
            return true;
        }

        string IWorksDriver.IWorksDriver.GetErrorInfo()
        {
            return " ";
        }

        IPictureDisp IWorksDriver.IWorksDriver.Get32x32Bitmap(string CommandName)
        {
            return null;
        }

        ReturnCode IWorksDriver.IWorksDriver.PrepareForRun(string LocationInfoXML)
        {
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        string IWorksDriver.IWorksDriver.GetDescription(string CommandXML, bool Verbose)
        {
            return " ";
        }

        ReturnCode IWorksDriver.IWorksDriver.PlateDroppedOff(string PlateInfoXML)
        {
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        ReturnCode IWorksDriver.IWorksDriver.PlatePickedUp(string PlateInfoXML)
        {
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        void IWorksDriver.IWorksDriver.PlateTransferAborted(string PlateInfoXML)
        {
            // TODO
        }

        string IWorksDriver.IWorksDriver.ControllerQuery(string Query)
        {
            // Not implemented
            return "";
        }

        IPictureDisp IWorksDriver.IWorksDriver.GetLayoutBitmap(string LayoutInfoXML)
        {
            // Not implemented or necessary
            return null;
        }

        string IWorksDriver.IWorksDriver.Compile(CompileType iCompileType, string MetaDataXML)
        {
            // No errors or warnings to report, basically ever.
            return "";
        }

        void IWorksDiags.ShowDiagsDialog(SecurityLevel iSecurity, bool bModal)
        {
            // TODO
        }

        ReturnCode IWorksDiags.CloseDiagsDialog()
        {
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        ReturnCode IWorksDiags.IsDiagsDialogOpen()
        {
            return IWorksDriver.ReturnCode.RETURN_SUCCESS;
        }

        void IControllerClient.SetController(CWorksController Controller)
        {
            controllerInstance = Controller;
        }
    }
}
