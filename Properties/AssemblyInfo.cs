using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MT.Versioner")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(GlobalVersion.Company)]
[assembly: AssemblyProduct("MT.Versioner" + GlobalVersion.BuildType)]
[assembly: AssemblyCopyright(GlobalVersion.Copyright)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: SatelliteContractVersionAttribute("1.0.0.0")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("451f2834-b1e3-447f-9251-c4069edd71f9")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
[assembly: AssemblyVersion(GlobalVersion.Version)]
[assembly: AssemblyFileVersion(GlobalVersion.Version)]
#pragma warning disable 1607
[assembly: AssemblyInformationalVersionAttribute(GlobalVersion.SvnPath)]


public static class GlobalVersion
{
    public const string MajorVersion = SvnInformation.MEW_MAJOR_VERSION;
    public const string MinorVersion = SvnInformation.MEW_MINOR_VERSION;
    public const string BuildNumber = SvnInformation.SVN_REVISION_NUMBER;
    public const string Revision = SvnInformation.MEW_REVISION;
    public const string Version = MajorVersion + "." + MinorVersion + "." + BuildNumber + "." + Revision;
    public const string SvnPath = SvnInformation.SVN_PATH;

#if DEBUG
    public const string BuildType = "(Debug)";
#else
    public const string BuildType = "";
#endif

    public const string Copyright = SvnInformation.COPYRIGHT;
    public const string Company = SvnInformation.COMPANY;
    public const string CompanyShort = SvnInformation.COMPANY_SHORT;

    //http://msdn.microsoft.com/en-us/library/windows/desktop/dd378459%28v=vs.85%29.aspx
    //    How to Form an Application-Defined AppUserModelID

    //An application must provide its AppUserModelID in the following form. It can have no more than 128 characters and cannot contain spaces. Each section should be camel-cased.

    //CompanyName.ProductName.SubProduct.VersionInformation

    //CompanyName and ProductName should always be used, while the SubProduct and VersionInformation portions are optional and depend on the application's requirements. SubProduct allows a main application that consists of several subapplications to provide a separate taskbar button for each subapplication and its associated windows. VersionInformation allows two versions of an application to coexist while being seen as discrete entities. If an application is not intended to be used in that way, the VersionInformation should be omitted so that an upgraded version can use the same AppUserModelID as the version that it replaced.
    public const string AppUserModelID = SvnInformation.APP_USER_MODEL_ID;

    /// <summary>
    /// Compares 2 strings of versions got by GlobalVersion.Version in format "major.minor.buildno.revision"
    /// </summary>
    /// <param name="first">First version object</param>
    /// <param name="second">Second version object</param>
    /// <returns>0 when are equal; -1 when first is smaller; 1 when first is bigger</returns>
    public static int Compare(string first, string second)
    {
        if (first == second)
            return 0;

        var firstParts = first.Split(new[] { '.' });
        var secondParts = second.Split(new[] { '.' });
        if (firstParts.Length != 4 || secondParts.Length != 4)
            throw new System.ArgumentException("First or Second parametr is not valid version string. Valid version string is x.y.z.a, where x,y,z,a are integers");

        for (int i = 0; i < 4; i++)
        {
            int firstPart, secondPart;
            if (!int.TryParse(firstParts[i], out firstPart) || !int.TryParse(secondParts[i], out secondPart))
                throw new System.ArgumentException("First or Second parametr is not valid version string. Valid version string is x.y.z.a, where x,y,z,a are integers");

            if (firstPart < secondPart)
                return -1;
            else if (firstPart > secondPart)
                return 1;
            else
                continue;
        }

        return 0;
    }
}
