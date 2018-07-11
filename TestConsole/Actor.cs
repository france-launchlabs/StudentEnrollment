using System;
namespace TestConsole
{
    public class Actor
    {
        public Actor()
        {
            
        }
        private string jobTitle;

        /// <summary>
        /// Gets the occupation.
        /// </summary>
        /// <returns>The occupation.</returns>
        public string GetOccupation(){
            jobTitle = "Actor";
            return jobTitle;
        }
    }
}
