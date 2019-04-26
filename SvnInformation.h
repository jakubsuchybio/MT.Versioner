
// Radek nahore musi byt volny, problem s UTF-8 v resource compileru pro C++ projekty
// CSHARP_SHEEP je definovany v projektu MT.Versioner, aby se kod uvnitr zpracovaval pouze pro C#

#if __CSHARP_SHEEP__

public static class SvnInformation
{
    public const string MEW_MAJOR_VERSION = "3";
    public const string MEW_MINOR_VERSION = "0";
    public const string MEW_REVISION = "0";
    public const string SVN_REVISION_NUMBER = "65534";
    public const string SVN_PATH = "";//prepisuje se na buildovacim stroji
    public const string COPYRIGHT = "Copyright © " + COMPANY + " " + COPYRIGHT_YEAR;
    public const string COPYRIGHT_YEAR = "2017";
    public const string COMPANY = "<COMPANY_NAME>";
    public const string COMPANY_SHORT = "<COMPANY_SHORT_NAME>";
    public const string APP_USER_MODEL_ID = "<APP_USER_MODEL_ID>";
}

#else

// komentar pred definem je hack pro C#
// v C# nesmi define fungovat jako konstanta

// str -> "str"
/**/#define QUOTE(str) #str
/**/#define QUOTE_(str) QUOTE(str)

/**/#ifdef _DEBUG
/**/  #define CONFIG          " (DEBUG)"
/**/#else
/**/  #define CONFIG          ""
/**/#endif

/**/#define MEW_MAJOR_VERSION 3
/**/#define MEW_MINOR_VERSION 0
/**/#define MEW_REVISION 0
/**/#define SVN_REVISION_NUMBER 65534
/**/#define LEGAL_COPYRIGHT		"Copyright (c) " COMPANY_NAME " " COPYRIGHT_YEAR
/**/#define COPYRIGHT_YEAR		"2017"
/**/#define COMPANY_NAME		"<COMPANY_NAME>"
/**/#define COMPANY_SHORT_NAME	"<COMPANY_SHORT_NAME>"
/**/#define LEGAL_TRADEMARKS	"none"

#endif

