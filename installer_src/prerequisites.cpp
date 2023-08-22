#include <stdlib.h>
#include <iostream>
#include "prerequisites.h"

using namespace Installer;

int Prerequisites::checkgetpy(void)
{
    int py = Prerequisites::checkpy();
    // if python is not found
    if (py != 0)
    {
        // try and install python, return 1 if failed
        int get = Prerequisites::getpy();
        if (get != 0)
        {
            // TODO: add troubleshooting if shit goes wrong (such as upgrading python etc.)
            std::cout << "Something went wrong when trying to install Python" << std::endl;
            return 1;
        }
    }
    return 0;
}

int Prerequisites::checkgetpip(void)
{
    int pip = Prerequisites::checkpip();
    // if pip is not found
    if (pip != 0)
    {
        // try and install pip, return 1 if failed
        int get = Prerequisites::getpip();
        if (get != 0)
        {
            std::cout << "Something went wrong when trying to install Python" << std::endl;
            return 1;
        }
    }
    return 0;
}

int Prerequisites::checkgetse(void)
{
    int se = Prerequisites::checkse();
    // if selenium ('se') is not installed
    if (se != 0)
    {
        // try and install the selenium PyPI package, return 1 if failed
        int get = Prerequisites::getse();
        if (get != 0)
        {
            std::cout << "Something went wrong when trying to get the selenium PyPI package" << std::endl;
            return 1;
        }
    }
    return 0;
}

int Prerequisites::checkgetgit(void)
{
    int git = Prerequisites::checkgit();
    // if git is not found
    if (git != 0)
    {
        // try and install git, return 1 if failed
        int get = Prerequisites::getgit();
        if (get != 0)
        {
            std::cout << "Something went wrong when trying to install git" << std::endl;
            return 1;
        }
    }
    return 0;
}

statuscode Prerequisites::checks(void)
{
    int py = Prerequisites::checkpy();
    if (py != 0)
    {
        statuscode status;
        status.location = 1;
        status.exitcode = py;
        return status;
    }
    int pip = Prerequisites::checkpip();
    if (pip != 0)
    {
        statuscode status;
        status.location = 2;
        status.exitcode = pip;
        return status;
    }
    int se = Prerequisites::checkse();
    if (se != 0)
    {
        statuscode status;
        status.location = 3;
        status.exitcode = se;
        return status;
    }
    int git = Prerequisites::checkgit();
    if (git != 0)
    {
        statuscode status;
        status.location = 4;
        status.exitcode = git;
        return status;
    }
    statuscode status;
    status.location = 0;
    status.exitcode = 0;
    return status;
}

//only use if you want to force all
statuscode Prerequisites::gets()
{
    int py = Prerequisites::getpy();
    if (py != 0)
    {
        statuscode status;
        status.location = 1;
        status.exitcode = py;
        return status;
    }
    int pip = Prerequisites::getpip();
    if (pip != 0)
    {
        statuscode status;
        status.location = 2;
        status.exitcode = pip;
        return status;
    }
    int se = Prerequisites::getse();
    if (se != 0)
    {
        statuscode status;
        status.location = 3;
        status.exitcode = se;
        return status;
    }
    int git = Prerequisites::getgit();
    if (git != 0)
    {
        statuscode status;
        status.location = 4;
        status.exitcode = git;
        return status;
    }
    statuscode status;
    status.location = 0;
    status.exitcode = 0;
    return status;
}

statuscode Prerequisites::checkgets(void)
{
    int py = Prerequisites::checkgetpy();
    if (py != 0)
    {
        statuscode status;
        status.location = 1;
        status.exitcode = py;
        return status;
    }
    int pip = Prerequisites::checkgetpip();
    if (pip != 0)
    {
        statuscode status;
        status.location = 2;
        status.exitcode = pip;
        return status;
    }
    int se = Prerequisites::checkgetse();
    if (se != 0)
    {
        statuscode status;
        status.location = 3;
        status.exitcode = se;
        return status;
    }
    int git = Prerequisites::checkgetgit();
    if (git != 0)
    {
        statuscode status;
        status.location = 4;
        status.exitcode = git;
        return status;
    }
    statuscode status;
    status.location = 0;
    status.exitcode = 0;
    return status;
}

statuscode Prerequisites::updates(void)
{
    int py = Prerequisites::uppy();
    if (py != 0)
    {
        statuscode status;
        status.location = 1;
        status.exitcode = py;
        return status;
    }
    int pip = Prerequisites::uppip();
    if (pip != 0)
    {
        statuscode status;
        status.location = 2;
        status.exitcode = pip;
        return status;
    }
    int se = Prerequisites::upse();
    if (se != 0)
    {
        statuscode status;
        status.location = 3;
        status.exitcode = se;
        return status;
    }
    int git = Prerequisites::upgit();
    if (git != 0)
    {
        statuscode status;
        status.location = 4;
        status.exitcode = git;
        return status;
    }
    statuscode status;
    status.location = 0;
    status.exitcode = 0;
    return status;
}
