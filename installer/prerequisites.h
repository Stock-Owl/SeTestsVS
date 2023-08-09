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
            // all previous checkget* functions combined
            statuscode checkgets(void);

        private:
            //
            static int checkpy(void){return system("python --version");}
            static int checkpip(void){return system("pip --version");}
            static int checkse(void){return system("pip show selenium");}
            static int checkgit(void){return system("git --version");}
            //
            static int getpy(void){return system("winget install -e --id Python.Python.3.11");}
            static int getpip(void){return system("python get-pip.py");}
            static int getse(void){return system("pip install selenium");}
            static int getgit(void){return system("winget install --id Git.Git -e --source winget");}
            // all previous get* functions combined
            statuscode gets(void);
    };

}
#endif // _PREREQUISITES_