using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class DoorEntry
    {
        // fields
        private string _studentID;
        private int _doorCode;
        private string _status;

        // constructor ########################################################
        /// <summary>
        /// Initialises the object to the values passed in
        /// </summary>
        /// <param name="student">The student identification</param>
        /// <param name="door">The QR Code of the door</param>
        /// <param name="status">Whether the student was in this room</param>
        public DoorEntry(string student, int door, string status)
        {
            _studentID = student;
            _doorCode = door;
            _status = status;
        }

        // properties ########################################################
        /// <summary>
        /// This property gets the ID of the student
        /// </summary>
        public string Student
        {
            get { return _studentID; }
            set { _studentID = value; }
        }

        /// <summary>
        /// Gets the door codes 
        /// </summary>
        public int Door
        {
            get { return _doorCode; }
            set
            {
                // error checking - ensure the code is between 1 and 24
                if (value > 1 && value < 24)
                {
                    _doorCode = value;
                }
                else
                {
                    throw new Exception("Door code is incorrect");
                }
            }
        }

        /// <summary>
        /// Gets the status of the student either in or out
        /// </summary>
        public string Status
        {
            get { return _status; }
            set
            {
                // error check - making sure that the input is either in or out defaulting to out if any other string is used
                if (value != "in" || value != "out")
                {
                    // add value to _status
                    _status = value;
                }
                else
                {
                    throw new Exception("Out");
                }
            }
        }

        /// <summary>
        /// Gets all the information about which room the student was in 
        /// </summary>
        /// <returns>Back all of the student information padded out</returns>
        public override string ToString()
        {
            return Student.PadRight(10) + Door.ToString().PadRight(5) + Status.PadLeft(10);
        }
    }
}
