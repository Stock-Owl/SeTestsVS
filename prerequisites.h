// header file to check if  is the prerequisites are istalled
// v1.0.0

#pragma once

#ifndef _PREREQUISITES_
#define _PREREQUISITES_

#include <stdlib.h>
#include <iostream>

namespace Installer
{

    struct statuscode
    {
        int location;
        int exitcode;
    };

    class Prerequisites
    {
    public:
        //
        static int checkgetpy(void);
        static int checkgetpip(void);
        static int checkgetse(void);
        static int checkgetgit(void);

        static inline int uppy(void) { return getpy(); };
        static inline int uppip(void) { return system("python -m pip install --upgrade pip"); };
        static inline int upse(void) { return system("pip uninstall selenium && pip install selenium"); };
        static inline int upgit(void) { return system("git update-git-for-windows"); };
        // all previous checkget*, get* and check* functions combined
        static statuscode checkgets(void);
        static statuscode gets(void);
        static statuscode checks(void);
        static statuscode updates(void);

    private:
        //
        static inline int checkpy(void) { return system("python --version"); }
        static inline int checkpip(void) { return system("pip --version"); }
        static inline int checkse(void) { return system("pip show selenium"); }
        static inline int checkgit(void) { return system("git --version"); }
        //
        static inline int getpy(void) { return system("winget install --silent -e --id Python.Python.3.11"); }
        static inline int getpip(void) { return system("python get-pip.py"); }
        static inline int getse(void) { return system("pip install selenium"); }
        static inline int getgit(void) { return system("winget install --silent --id Git.Git -e --source winget"); }
    };

}
#endif // _PREREQUISITES_