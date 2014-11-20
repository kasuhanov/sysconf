using System;
using System.Management;


namespace ConsoleApplication3
{
    class Program
    {
        static void Main()
        {
            String str = "";
            #region Win32_ComputerSystem
            var query = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            var queryCollection = query.Get();
            String[] param = { "Caption", "UserName", "Domain", "DomainRole", "PartOfDomain", 
                                 "TotalPhysicalMemory", "Manufacturer", "Model", "NumberOfProcessors",
                                 "NumberOfLogicalProcessors","PCSystemType","PowerState","SystemType" //12
                                 
                             };
            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject) o;
                var name = mo[param[0]].ToString(); //получаем имя пк
                var username = mo[param[1]].ToString(); //получаем имя пк
                var dom = (mo[param[2]]).ToString(); //получаем domain
                var domRole = (mo[param[3]]).ToString(); //получаем domainRole
                #region DomainRole switch
                switch (domRole)
                {
                    case "0":
                        domRole = "Standalone Workstation";
                        break;
                    case "1":
                        domRole = "Member Workstation";
                        break;
                    case "2":
                        domRole = "Standalone Server";
                        break;
                    case "3":
                        domRole = "Member Server";
                        break;
                    case "4":
                        domRole = "Backup Domain Controller";
                        break;
                    case "5":
                        domRole = "Primary Domain Controller";
                        break;
                }
                #endregion
                //var partOfDom = (mo[param[4]]).ToString(); //получаем PartOfDomain
                var mem = (mo[param[5]]).ToString(); //получаем количество памяти
                var manuf = (mo[param[6]]).ToString(); 
                var model = (mo[param[7]]).ToString(); 
                var procnum = (mo[param[8]]).ToString(); 
                var logprocnum = (mo[param[9]]).ToString(); 
                var systype = (mo[param[10]]).ToString();
                #region Pc system type switch
                switch (systype)
                {
                    case "0":
                        systype = "Unspecified";
                        break;
                    case "1":
                        systype = "Desktop";
                        break;
                    case "2":
                        systype = "Mobile";
                        break;
                    case "3":
                        systype = "Workstation";
                        break;
                    case "4":
                        systype = "Enterprise Server";
                        break;
                    case "5":
                        systype = "Small Office and Home Office (SOHO) Server";
                        break;
                    case "6":
                        systype = "Appliance PC";
                        break;
                    case "7":
                        systype = "Performance Server";
                        break;
                    case "8":
                        systype = "Maximum";
                        break;
                }
                #endregion
                var powerState = (mo[param[11]]).ToString();
                #region PowerState switch
                switch (powerState)
                {
                    case "0":
                        powerState = "Unknown";
                        break;
                    case "1":
                        powerState = "Full Power";
                        break;
                    case "2":
                        powerState = "Power Save - Low Power Mode";
                        break;
                    case "3":
                        powerState = "Power Save - Standby";
                        break;
                    case "4":
                        powerState = "Power Save - Unknown";
                        break;
                    case "5":
                        powerState = "Power Cycle";
                        break;
                    case "6":
                        powerState = "Power Off";
                        break;
                    case "7":
                        powerState = "Power Save - Warning";
                        break;
                }
                #endregion
                var systemType = (mo[param[12]]).ToString();

                str += "    System Informarion\n\n";
                //Console.WriteLine("PC name=" + name ); 
                str += "PC name=" + name + "\n";
                //Console.WriteLine("Username=" + username ); 
                str += "Username=" + username + "\n";
                //Console.WriteLine("Domain=" + dom ); 
                str += "Domain=" + dom + "\n";
                //Console.WriteLine("Domain role=" + domRole );
                str += "Domain role=" + domRole + "\n";
                //Console.WriteLine("RAM=" + mem + " b");
                str += "RAM=" + mem + " b" + "\n";
                //Console.WriteLine("Manufacturer=" + manuf);
                str += "Manufacturer=" + manuf + "\n";
                //Console.WriteLine("Model=" + model);
                str += "Model=" + model + "\n";
                //Console.WriteLine("Number Of Processors=" + procnum);
                str += "Number Of Processors=" + procnum + "\n";
                //Console.WriteLine("Number Of Logical Processors=" + logprocnum);
                str += "Number Of Logical Processors=" + logprocnum + "\n";
                //Console.WriteLine("System Type=" + systype);
                str += "System Type=" + systype + "\n";
                //Console.WriteLine("Power State=" + powerState);
                str += "Power State=" + powerState + "\n";
                //Console.WriteLine("System type=" + systemType);
                str += "System type=" + systemType + "\n";


            }
            #endregion
            #region Win32_PnPEntity
            /*query = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity");
            queryCollection = query.Get();
            String[] param2 = { "Name", "Status", "Manufacturer" };

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param2[0]] != null)
                {
                    var name = mo[param2[0]].ToString();
                    Console.WriteLine("Name=" + name);
                }
                if (mo[param2[1]] != null)
                {
                    var status = mo[param2[1]];
                    Console.WriteLine(" Status=" + status);
                }
                if (mo[param2[2]] != null)
                {
                    var manufacturer = mo[param2[2]].ToString();
                    Console.WriteLine(" Manufacturer=" + manufacturer);
                }
            }
            */
            #endregion
            #region Win32_BaseBoard
            query = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            queryCollection = query.Get();
            String[] param3 = { "Caption", "Description", "Manufacturer", "Product", "SerialNumber", "Tag", "Version" };
            str += "\n    Board Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param3[0]] != null)
                {
                    var caption = mo[param3[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param3[1]] != null)
                {
                    var description = mo[param3[1]];
                    //Console.WriteLine(" Description=" + description);
                    str += " Description=" + description + "\n";
                }
                if (mo[param3[2]] != null)
                {
                    var manufacturer = mo[param3[2]].ToString();
                    //Console.WriteLine(" Manufacturer=" + manufacturer);
                    str += " Manufacturer=" + manufacturer + "\n";
                }
                if (mo[param3[3]] != null)
                {
                    var product = mo[param3[3]].ToString();
                    //Console.WriteLine(" Product=" + product);
                    str += " Product=" + product + "\n";
                }
                if (mo[param3[4]] != null)
                {
                    var serialNumber = mo[param3[4]].ToString();
                    //Console.WriteLine(" Serial Number=" + serialNumber);
                    str += " Serial Number=" + serialNumber + "\n";
                }
                if (mo[param3[5]] != null)
                {
                    var tag = mo[param3[5]].ToString();
                    //Console.WriteLine(" Tag=" + tag);
                    str += " Tag=" + tag + "\n";
                }
                if (mo[param3[6]] != null)
                {
                    var version = mo[param3[6]].ToString();
                    //Console.WriteLine(" Version=" + version);
                    str += " Version=" + version + "\n";
                }
            }
            #endregion
            #region Win32_OnBoardDevice
            query = new ManagementObjectSearcher("SELECT * FROM Win32_OnBoardDevice");
            queryCollection = query.Get();
            String[] param4 = { "Caption", "Description", "DeviceType" };
            str += "\n    On Board Device Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param4[0]] != null)
                {
                    var caption = mo[param4[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param4[1]] != null)
                {
                    var description = mo[param4[1]];
                    //Console.WriteLine(" Description=" + description);
                    str += " Description=" + description + "\n";
                }
                if (mo[param4[2]] != null)
                {
                    var deviceType = mo[param4[2]].ToString();
                    #region DeviceType switch
                    switch (deviceType)
                    {
                        case "6":
                            deviceType = "Token Ring";
                            break;
                        case "7":
                            deviceType = "Sound";
                            break;
                        case "1":
                            deviceType = "Other";
                            break;
                        case "2":
                            deviceType = "Unknown";
                            break;
                        case "3":
                            deviceType = "Video";
                            break;
                        case "4":
                            deviceType = "SCSI Controller";
                            break;
                        case "5":
                            deviceType = "Ethernet";
                            break;
                    }
                    #endregion
                    //Console.WriteLine(" DeviceType=" + DeviceType);
                    str += " DeviceType=" + deviceType + "\n";
                }
            }
            #endregion
            #region Win32_Bus
            query = new ManagementObjectSearcher("SELECT * FROM Win32_Bus");
            queryCollection = query.Get();
            String[] param5 = { "Caption", "DeviceID", "BusType" };
            str += "\n    Bus Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param5[0]] != null)
                {
                    var caption = mo[param5[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param5[1]] != null)
                {
                    var deviceId = mo[param5[1]];
                    //Console.WriteLine(" DeviceID =" + DeviceID);
                    str += " DeviceID =" + deviceId + "\n";
                }
                if (mo[param5[2]] != null)
                {
                    var busType = mo[param5[2]].ToString();
                    #region BusType  switch
                    switch (busType)
                    {
                        case "15":
                            busType = "PNP Bus";
                            break;
                        case "1":
                            busType = "ISA";
                            break;
                        case "2":
                            busType = "EISA";
                            break;
                        case "3":
                            busType = "MicroChannel";
                            break;
                        case "4":
                            busType = "SCSI TurboChannel";
                            break;
                        case "5":
                            busType = "PCI Bus";
                            break;
                        case "6":
                            busType = "VME Bus";
                            break;
                        case "7":
                            busType = "NuBus";
                            break;
                        case "8":
                            busType = "PCMCIA Bus";
                            break;
                        case "9":
                            busType = "C Bus";
                            break;
                        case "10":
                            busType = "MPI Bus";
                            break;
                        case "11":
                            busType = "MPSA Bus";
                            break;
                        case "12":
                            busType = "Internal Processor";
                            break;
                        case "13":
                            busType = "Internal Power Bus";
                            break;
                        case "14":
                            busType = "PNP ISA Bus";
                            break;
                        case "16":
                            busType = "Maximum Interface Type";
                            break;
                        default:
                            busType = "Unknown Bus Type";
                            break;
                    }
                    #endregion
                    //Console.WriteLine(" BusType =" + BusType);
                    str += " BusType =" + busType + "\n";
                }
            }
            #endregion
            #region Win32_Processor
            query = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            queryCollection = query.Get();
            String[] param6 = { "Caption", "Name", "Manufacturer", "CurrentClockSpeed", "LoadPercentage", "L2CacheSize", "L2CacheSpeed" };
            str += "\n    Processer Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o; 

                if (mo[param6[0]] != null)
                {
                    var caption = mo[param6[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param6[1]] != null)
                {
                    var name = mo[param6[1]];
                    //Console.WriteLine(" Name  =" + Name);
                    str += " Name  =" + name + "\n";
                }
                if (mo[param6[2]] != null)
                {
                    var manufacturer = mo[param6[2]].ToString();
                    //Console.WriteLine(" Manufacturer =" + Manufacturer);
                    str += " Manufacturer =" + manufacturer + "\n";
                }
                if (mo[param6[3]] != null)
                {
                    var currentClockSpeed = mo[param6[3]].ToString();
                    //Console.WriteLine(" CurrentClockSpeed =" + CurrentClockSpeed+" MHz");
                    str += " CurrentClockSpeed =" + currentClockSpeed + " MHz" + "\n";
                }
                if (mo[param6[4]] != null)
                {
                    var loadPercentage = mo[param6[4]].ToString();
                    //Console.WriteLine(" LoadPercentage  =" + LoadPercentage + " %");
                    str += " LoadPercentage  =" + loadPercentage + " %" + "\n";
                }
                if (mo[param6[5]] != null)
                {
                    var l2CacheSize = mo[param6[5]].ToString();
                    //Console.WriteLine(" L2CacheSizePerCore =" + L2CacheSize + " kb");
                    str += " L2CacheSizePerCore =" + l2CacheSize + " kb" + "\n";
                }
                if (mo[param6[6]] != null)
                {
                    var l2CacheSpeed = mo[param6[6]].ToString();
                    //Console.WriteLine(" L2CacheSpeed =" + L2CacheSpeed + " MHz");
                    str += " L2CacheSpeed =" + l2CacheSpeed + " MHz" + "\n";
                }
            }
            #endregion
            #region Win32_PhysicalMemory
            query = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            queryCollection = query.Get();
            String[] param7 = { "Name", "Capacity", "DeviceLocator", "MemoryType" };
            str += "\n    Physical Memory Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param7[0]] != null)
                {
                    var caption = mo[param7[0]].ToString();
                    //Console.WriteLine("Name=" + caption);
                    str += "Name=" + caption + "\n";
                }
                if (mo[param7[1]] != null)
                {
                    var capacity = mo[param7[1]];
                    //Console.WriteLine(" Capacity =" + Capacity+" b");
                    str += " Capacity =" + capacity + " b" + "\n";
                }
                if (mo[param7[2]] != null)
                {
                    var deviceLocator = mo[param7[2]].ToString();

                    //Console.WriteLine(" DeviceLocator =" + DeviceLocator);
                    str += " DeviceLocator =" + deviceLocator + "\n";
                }
                if (mo[param7[3]] != null)
                {
                    var memoryType = mo[param7[3]].ToString();
                    #region MemoryType  switch
                    switch (memoryType)
                    {
                       case "1":
                            memoryType = "Other";
                            break;
                        case "2":
                            memoryType = "DRAM";
                            break;
                        case "3":
                            memoryType = "Synchronous DRAM";
                            break;
                        case "4":
                            memoryType = "Cache DRAM";
                            break;
                        case "5":
                            memoryType = "EDO";
                            break;
                        case "6":
                            memoryType = "EDRAM";
                            break;
                        case "7":
                            memoryType = "VRAM";
                            break;
                        case "8":
                            memoryType = "SRAM";
                            break;
                        case "9":
                            memoryType = "RAM";
                            break;
                        case "10":
                            memoryType = "ROM";
                            break;
                        case "11":
                            memoryType = "Flash";
                            break;
                        case "12":
                            memoryType = "EEPROM";
                            break;
                        case "13":
                            memoryType = "FEPROM";
                            break;
                        case "14":
                            memoryType = "EPROM";
                            break;
                        case "15":
                            memoryType = "CDRAM";
                            break;
                        case "16":
                            memoryType = "3DRAM";
                            break;
                        case "17":
                            memoryType = "SDRAM";
                            break;
                        case "18":
                            memoryType = "SGRAM";
                            break;
                        case "19":
                            memoryType = "RDRAM";
                            break;
                        case "20":
                            memoryType = "DDR";
                            break;
                        case "21":
                            memoryType = "DDR-2";
                            break;
                        default:
                            memoryType = "Unknown";
                            break;
                    }
                    #endregion
                    //Console.WriteLine(" MemoryType =" + MemoryType);
                    str += " MemoryType =" + memoryType + "\n";
                }
            }
            #endregion
            #region Win32_Keyboard
            query = new ManagementObjectSearcher("SELECT * FROM Win32_Keyboard");
            queryCollection = query.Get();
            String[] param8 = { "Caption", "Description"  };
            str += "\n   Keyboard  Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param8[0]] != null)
                {
                    var caption = mo[param8[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param8[1]] != null)
                {
                    var capacity = mo[param8[1]];
                    //Console.WriteLine(" Description =" + Capacity);
                    str += " Description =" + capacity + "\n";
                }
                
            }
            #endregion
            #region Win32_PointingDevice
            query = new ManagementObjectSearcher("SELECT * FROM Win32_PointingDevice");
            queryCollection = query.Get();
            String[] param9 = { "Caption", "Description", "HardwareType", "Manufacturer" };
            str += "\n    Pointing Device Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param9[0]] != null)
                {
                    var caption = mo[param9[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param9[1]] != null)
                {
                    var capacity = mo[param9[1]];
                    //Console.WriteLine(" Description =" + Capacity);
                    str += " Description =" + capacity + "\n";
                }
                if (mo[param9[2]] != null)
                {
                    var hardwareType = mo[param9[2]];
                    //Console.WriteLine(" HardwareType =" + HardwareType);
                    str += " HardwareType =" + hardwareType + "\n";
                }
                if (mo[param9[3]] != null)
                {
                    var manufacturer = mo[param9[3]];
                    //Console.WriteLine(" Manufacturer =" + Manufacturer);
                    str += " Manufacturer =" + manufacturer + "\n";
                }

            }
            #endregion
            #region Win32_SoundDevice
            query = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");
            queryCollection = query.Get();
            String[] param10 = { "Caption", "ProductName", "Description", "Manufacturer" };
            str += "\n   Sound Device  Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param10[0]] != null)
                {
                    var caption = mo[param10[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param10[1]] != null)
                {
                    var productName = mo[param10[1]];
                    //Console.WriteLine(" ProductName =" + ProductName);
                    str += " ProductName =" + productName + "\n";
                }
                if (mo[param10[2]] != null)
                {
                    var description = mo[param10[2]];
                    //Console.WriteLine(" Description  =" + Description);
                    str += " Description  =" + description + "\n";
                }
                if (mo[param10[3]] != null)
                {
                    var manufacturer = mo[param10[3]];
                    //Console.WriteLine(" Manufacturer =" + Manufacturer);
                    str += " Manufacturer =" + manufacturer + "\n";
                }

            }
            #endregion
            #region Win32_VideoController
            query = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
            queryCollection = query.Get();
            String[] param11 = { "Caption", "AdapterRAM", "VideoModeDescription", "CurrentRefreshRate" };
            str += "\n    Videocontroller Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param11[0]] != null)
                {
                    var caption = mo[param11[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param11[1]] != null)
                {
                    var productName = mo[param11[1]];
                    //Console.WriteLine(" AdapterRAM =" + ProductName+" b");
                    str += " AdapterRAM =" + productName + " b" + "\n";
                }
                if (mo[param11[2]] != null)
                {
                    var description = mo[param11[2]];
                    //Console.WriteLine(" VideoModeDescription = " + Description);
                    str += " VideoModeDescription = " + description + "\n";
                }
                if (mo[param11[3]] != null)
                {
                    var manufacturer = mo[param11[3]];
                    //Console.WriteLine(" CurrentRefreshRate  =" + Manufacturer+" Hz");
                    str += " CurrentRefreshRate  =" + manufacturer + " Hz" + "\n";
                }

            }
            #endregion
            #region Win32_NetworkAdapter
            query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter ");
            queryCollection = query.Get();
            String[] param12 = { "Caption", "Manufacturer", "AdapterType", "MACAddress" };
            str += "\n    Network Adapter Informarion\n\n";

            foreach (var o in queryCollection)
            {
                var mo = (ManagementObject)o;

                if (mo[param12[0]] != null)
                {
                    var caption = mo[param12[0]].ToString();
                    //Console.WriteLine("Caption=" + caption);
                    str += "Caption=" + caption + "\n";
                }
                if (mo[param12[1]] != null)
                {
                    var productName = mo[param12[1]];
                    //Console.WriteLine(" Manufacturer  =" + ProductName );
                    str += " Manufacturer  =" + productName + "\n";
                }
                if (mo[param12[2]] != null)
                {
                    var description = mo[param12[2]];
                    //Console.WriteLine(" AdapterType = " + Description);
                    str += " AdapterType = " + description + "\n";
                }
                if (mo[param12[3]] != null)
                {
                    var manufacturer = mo[param12[3]];
                    //Console.WriteLine(" MACAddress =" + Manufacturer);
                    str += " MACAddress =" + manufacturer + "\n";
                }

            }
            #endregion
            Console.WriteLine(str);
            Console.Read();

        }
    }
}
