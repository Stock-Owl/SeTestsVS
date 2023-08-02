#include <iostream>
#include <stdlib.h>

int main(int argc, char* argv[])
{
    char* pyversion = "3.11";

    // installs python 3.11
    int pyinstalled = system("winget install -e --id Python.Python.3.11");
    if ((bool)pyinstalled)
    {
        std::cout << "Python "<< pyversion << " successfully installed" << std::endl;
    }
    else
    {
        std::cout << "Python " << pyversion << " could not be automatically installed" << std::endl
        << "To install Python" << pyversion << "manually, visit https://www.python.org/downloads/release/python-3114/" << std::endl;
    }
    
    //checks if pip is installed, if not, tries to install it
    int pipversion = system("pip --version");
    if (!(bool)pipversion)
    {
        int getpip = system("python get-pip.py");
        if (!(bool)getpip)
        {
            std::cout << "pip could not be installed" << std::endl
            << "Try running the commands:" << std::endl
            << "\tcurl https://bootstrap.pypa.io/get-pip.py -o get-pip.py" << std::endl
            << "\tpython get-pip.py" << std::endl;
            return 1;
        }
    }
    
    //install selenium using pip
    int getselenium = system("pip install selenium");
    if (!(bool)getselenium)
    {
        std::cout << "Python package 'selenium' could not be automatically installed" << std::endl
        << "To install it manually, visit https://www.selenium.dev/documentation/webdriver/getting_started/install_library/" << std::endl;
        return 1;
    }
    else
    {
        std::cout << "Python package 'selenium' succesfully installed" << std::endl;
    }

    return 0;
}