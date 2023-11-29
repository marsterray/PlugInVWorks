using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlugInBlueprint
{
    public class RobotState
    {
        public int AS { get; set; }
        public int HS { get; set; }
        public int SM { get; set; }
        public int ES { get; set; }
        public int PM { get; set; }
        public int EOB { get; set; }
        public int EOM { get; set; }
    }


    public class Meca500
    {
        public Socket Robot;

        public Meca500(string IPAddressString, int Port)
        {
            this.IPAddressString = IPAddressString;
            this.Port = Port;
        }

        public string IPAddressString { get; private set; }

        public int Port { get; private set; }

        public string SendCommand(string Command)
        {
            string ReturnString;

            if (Robot != null && Robot.Connected)
            {
                byte[] ReceiveBytes = new byte[1024];

                byte[] SendBytes = Encoding.ASCII.GetBytes(Command + "\n");

                Robot.Send(SendBytes);

                Robot.ReceiveTimeout = 1000;

                string MessageReceived = string.Empty;

                try
                {
                    int BytesReceived = Robot.Receive(ReceiveBytes);
                    MessageReceived = Encoding.ASCII.GetString(ReceiveBytes, 0, BytesReceived);
                }
                catch (SocketException)
                {
                    MessageReceived = "Error receiving data from the robot.";
                }

                ReturnString = MessageReceived;
            }
            else
            {
                ReturnString = "Robot Not Connected";
            }

            return ReturnString;
        }

        public string ReceiveResponse()
        {
            string ReturnString;

            if (Robot.Connected)
            {
                byte[] ReceiveBytes = new byte[1024];

                ArraySegment<byte> AsyncReceiveBytes = new ArraySegment<byte>(ReceiveBytes);

                Robot.ReceiveTimeout = 1000;

                string MessageReceived;
                try
                {
                    int BytesReceived = Robot.Receive(ReceiveBytes, SocketFlags.None);

                    MessageReceived = Encoding.ASCII.GetString(ReceiveBytes, 0, BytesReceived);
                }
                catch (Exception)
                {
                    //This will fail if there are no messages to read in the buffer
                    MessageReceived = "Message Queue Empty";
                }

                ReturnString = MessageReceived;
            }
            else
            {
                ReturnString = "Robot Not Connected";
            }

            return ReturnString;
        }

        public string ConnectRobot()
        {
            string ReturnString = string.Empty;

            IPAddress RobotIPAddress;

            if (IPAddress.TryParse(this.IPAddressString, out RobotIPAddress))
            {
                IPEndPoint RemoteEndPoint = new IPEndPoint(RobotIPAddress, 10000);

                byte[] ReceiveBytes = new byte[1024];

                Robot = new Socket(RobotIPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                Robot.Connect(RemoteEndPoint);

                int BytesReceived = Robot.Receive(ReceiveBytes);

                string MessageReceived = Encoding.ASCII.GetString(ReceiveBytes, 0, BytesReceived);

                ReturnString = MessageReceived;
            }
            else
            {
                ReturnString = "Invalid IP Address";
            }

            return ReturnString;
        }

        public void DisconnectRobot()
        {
            if (Robot != null && Robot.Connected)
            {
                Robot.Shutdown(SocketShutdown.Both);
                Robot.Close();
            }
        }

        public string ActivateRobot()
        {
            return SendCommand("ActivateRobot");
        }

        public string DeactivateRobot()
        {
            return SendCommand("DeactivateRobot");
        }

        public string ActivateSim()
        {
            return SendCommand("ActivateSim");
        }

        public string DeactivateSim()
        {
            string Response = SendCommand("DeactivateSim");
            return Response;
        }

        public string HomeRobot()
        {
            string Response = SendCommand("Home");
            return Response;
        }

        public string GetStatusRobot()
        {
            return SendCommand("GetStatusRobot\n");
        }

        public List<string> RobotStatus()
        {
            var robotStatus = JsonConvert.DeserializeObject<RobotState>(GetStatusRobot());

            var statusDescriptions = new List<string>
            {
                robotStatus.AS == 0 ? "Not activated" : "Activated",
                robotStatus.HS == 0 ? "Homing not performed" : "Homing performed",
                robotStatus.SM == 0 ? "Simulation mode disabled" : "Simulation mode enabled",
                robotStatus.ES == 0 ? "Robot is not in error" : "Robot is in error",
                robotStatus.PM == 0 ? "Robot is not in pause motion" : "Robot is in pause motion",
                robotStatus.EOB == 0 ? "Motion queue is not empty and robot is active" : "Robot is idle and motion queue is empty",
                robotStatus.EOM == 0 ? "Robot is moving" : "Robot is idle"
            };

            return statusDescriptions;
        }

        public string MovePose(MecaCartesianCoordinate DesiredPosition)
        {
            string PositionString = DesiredPosition.X + "," + DesiredPosition.Y + "," + DesiredPosition.Z + "," + DesiredPosition.Rx + "," + DesiredPosition.Ry + "," + DesiredPosition.Rz;

            string Response = SendCommand("MovePose(" + PositionString + ")\n");
            return Response;
        }

    }
}
