namespace MobileWidget.Models
{
    public class DeviceDetails
    {
        private string brand;
        private string model;
        private string id;
        private string sdk;
        private string sdkint;
        private string manufacturer;
        private string socmanufacturer;
        private string socmodel;
        private string user;
        private string incremental;
        private string board;
        private string host;
        private string fingerprint;
        private string release;
        private string releaseorcodename;

        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Id { get => id; set => id = value; }
        public string Sdk { get => sdk; set => sdk = value; }
        public string Sdkint { get => sdkint; set => sdkint = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Socmanufacturer { get => socmanufacturer; set => socmanufacturer = value; }
        public string Socmodel { get => socmodel; set => socmodel = value; }
        public string User { get => user; set => user = value; }
        public string Incremental { get => incremental; set => incremental = value; }
        public string Board { get => board; set => board = value; }
        public string Host { get => host; set => host = value; }
        public string Fingerprint { get => fingerprint; set => fingerprint = value; }
        public string Release { get => release; set => release = value; }
        public string Releaseorcodename { get => releaseorcodename; set => releaseorcodename = value; }
    }
}
