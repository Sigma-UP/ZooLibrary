namespace ZooLib.Employees.Validators.Errors
{
    public class ValidationError
    {
        private string Message {get;set;}
        private string Property { get; set; }
        public ValidationError(string msg, string ppt)
        {
            Message = msg;
            Property = ppt;
        }
    }
}
