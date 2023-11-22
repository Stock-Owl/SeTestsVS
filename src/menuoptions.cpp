#include <fstream>
#include <iostream>
#include <string>
#include <conio.h>
#include "prerequisites.h"
#include "menu.h"
#include "menuoptions.h"
#include "json.h"

using namespace Installer;

Menu Menuoptions::init_main(void)
{
    std::vector<std::string> options;
    options.push_back("Install");
    options.push_back("Update");
    options.push_back("Check Dependency");
    options.push_back("Update Dependency");
    options.push_back("Reinstall");
    options.push_back("Uninstall");
    options.push_back("Report error");
    options.push_back("Troubleshooting");
    options.push_back("Dependencies [INFO]");
    options.push_back("About [INFO]");
    options.push_back("Exit");

    std::vector<std::string> values;
    values.push_back("ins");
    values.push_back("up");
    values.push_back("chck_dep");
    values.push_back("up_dep");
    values.push_back("reins");
    values.push_back("unins");
    values.push_back("rep");
    values.push_back("trouble");
    values.push_back("dep");
    values.push_back("abt");
    values.push_back("exit");

    return Menu(options, values);
}

Menu Menuoptions::init_dependencies(void)
{
    std::vector<std::string> options;
    options.push_back("Python");
    options.push_back("Python Install Package (pip)");
    options.push_back("Selenium");
    options.push_back("Git");
    options.push_back("All");
    options.push_back("Exit");

    std::vector<std::string> values;
    values.push_back("py");
    values.push_back("pip");
    values.push_back("se");
    values.push_back("git");
    values.push_back("exit");

    return Menu("Dependencies:", options, values);
}

int Menuoptions::Install(std::string path)
{
    std::ifstream file(path.c_str());
    nlohmann::json parsed_json = nlohmann::json::parse(file);
    std::string install_path = parsed_json["install_path"];
    file.close();

    if (install_path.empty() || install_path == "")
    {
        std::cout << "Provide the path where you want to install the program: ";
        std::getline(std::cin, install_path);
    }

    // cd "<installpath>" && git clone -b "<branch> https://github.com/Stock-Owl/SeTestsVS.git"
    std::string install_cmd = "cd \"" + install_path + "\" && git clone -b \"distribution\" https://github.com/Stock-Owl/SeTestsVS.git";

    // converts the modified json back to std::string then writes it into the original .json file
    std::ofstream wfile(path.c_str());
    parsed_json["install_path"] = install_path;
    std::string json_string = parsed_json.dump(2);
    wfile << json_string;
    wfile.close();

    int install_rv = system(install_cmd.c_str());
    return install_rv;
}

int Menuoptions::Update(std::string path)
{
    std::ifstream file(path.c_str());
    nlohmann::json parsed_json = nlohmann::json::parse(file);
    std::string install_path = parsed_json["install_path"];
    file.close();

    if (install_path.empty() || install_path == "")
    {
        std::cout << "No installation found at path: \'" << install_path << "\'" << std::endl
            << "Try to use \'Install\' from the menu!" << std::endl;
        return 1;
    }

    // cd "<installpath>" && git pull"
    std::string update_cmd = "cd \"" + install_path + "\" && git pull";

    int install_rv = system(update_cmd.c_str());
    return install_rv;
}

int Menuoptions::Checkdep(void)
{
    Menu dependecy_menu = init_dependencies();
    std::string dependency = dependecy_menu.take_input();
    if (dependency == "py")
    {
        int py = Prerequisites::checkgetpy();
        return py;
    }
    else if (dependency == "pip")
    {
        int pip = Prerequisites::checkgetpip();
        return pip;
    }
    else if (dependency == "se")
    {
        int se = Prerequisites::checkgetse();
        return se;
    }
    else if (dependency == "git")
    {
        int git = Prerequisites::checkgetgit();
        return git;
    }
    else if (dependency == "all")
    {
        statuscode checks = Prerequisites::checkgets();
        switch (checks.location)
        {
        case 1:
            std::cout << "Python could not be installed or reached. Exitcode: " << checks.exitcode << std::endl;
            break;
        case 2:
            std::cout << "Python Install Package (pip) could not be installed or reached. Exitcode: " << checks.exitcode << std::endl;
            break;
        case 3:
            std::cout << "The Selenium PyPI package could not be installed or reached. Exitcode: " << checks.exitcode << std::endl;
            break;
        case 4:
            std::cout << "Git could not be installed or reached. Exitcode: " << checks.exitcode << std::endl;
            break;
        }
        return checks.exitcode;
    }

    return 0;
}

int Menuoptions::Updatedep(void)
{
    Menu dependecy_menu = init_dependencies();
    std::string dependency = dependecy_menu.take_input();
    if (dependency == "py")
    {
        int py = Prerequisites::uppy();
        return py;
    }
    else if (dependency == "pip")
    {
        int pip = Prerequisites::uppip();
        return pip;
    }
    else if (dependency == "se")
    {
        int se = Prerequisites::upse();
        return se;
    }
    else if (dependency == "git")
    {
        int git = Prerequisites::upgit();
        return git;
    }
    else if (dependency == "all")
    {
        statuscode checks = Prerequisites::updates();
        switch (checks.location)
        {
        case 1:
            std::cout << "Python could not be updated or reached. Exitcode: " << checks.exitcode << std::endl
                << "You can try to check/install it in the \'Check Dependency\' menu" << std::endl;
            break;
        case 2:
            std::cout << "Python Install Package (pip) could not be updated or reached. Exitcode: " << checks.exitcode << std::endl
                << "You can try to check/install it in the \'Check Dependency\' menu" << std::endl;
            break;
        case 3:
            std::cout << "The Selenium PyPI package could not be updated or reached. Exitcode: " << checks.exitcode << std::endl
                << "You can try to check/install it in the \'Check Dependency\' menu" << std::endl;
            break;
        case 4:
            std::cout << "Git could not be updated or reached. Exitcode: " << checks.exitcode << std::endl
                << "You can try to check/install it in the \'Check Dependency\' menu" << std::endl;
            break;
        }
        return checks.exitcode;
    }

    return 0;
}

int Menuoptions::Reinstall(std::string path)
{
    std::ifstream file(path.c_str());
    nlohmann::json parsed_json = nlohmann::json::parse(file);
    std::string install_path = parsed_json["install_path"];
    file.close();

    if (install_path.empty() || install_path == "")
    {
        std::cout << "Provide the path where you want to install the program: ";
        std::cin >> install_path;
    }

    // which branch to pull from with git
    std::string branch = parsed_json["branch"];

    // cd "<installpath>" && rmdir /s /f SeTestsVS && git clone -b "<branch>" https://github.com/Stock-Owl/SeTestsVS.git"
    std::string install_cmd = "cd \"" + install_path + "\" && rmdir /s /f \"SeTestsVS\" && git clone -b \"" + branch + "\" https://github.com/Stock-Owl/SeTestsVS.git";

    int install_rv = system(install_cmd.c_str());
    return install_rv;
}

int Menuoptions::Uninstall(std::string path)
{
    std::ifstream file(path.c_str());
    nlohmann::json parsed_json = nlohmann::json::parse(file);
    std::string install_path = parsed_json["install_path"];
    file.close();

    if (install_path.empty() || install_path == "")
    {
        std::cout << "Provide the path where you want to install the program: ";
        std::cin >> install_path;
    }

    // which branch to pull from with git
    std::string branch = parsed_json["branch"];

    // cd "<installpath>" && rmdir /s /f SeTestsVS && git clone -b "<branch> https://github.com/Stock-Owl/SeTestsVS.git"
    std::string install_cmd = "cd \"" + install_path + "\" && rmdir /s /f \"SeTestsVS\"";

    // converts the modified json back to std::string then writes it into the original .json file
    std::ofstream wfile(path.c_str());
    parsed_json["install_path"] = "";
    std::string json_string = parsed_json.dump(2);
    wfile << json_string;
    wfile.close();

    int install_rv = system(install_cmd.c_str());
    return install_rv;
}

int Menuoptions::Report(void)
{
    std::string cmd = "rundll32 url.dll,FileProtocolHandler https://github.com/Stock-Owl/SeTestsVS/issues";
    int open_issues = system(cmd.c_str());

    return open_issues;
}

int Menuoptions::Troubleshooting()
{
    std::cout
        << "If something isn't working follow these steps in order.\nIf your problem isn't fixed, proceed to the next step:\n" << std::endl
        << "1. Use the \'Check Dependency\' menu to check a possibly missing depdencdency" << std::endl
        << "2. Use the \'Update Dependency\' to update any outdated or possibly deprecated dependencies" << std::endl
        << "3. Try to update the software using the \'Update\' option in the main menu" << std::endl
        << "4. Try to reinstall the software using the \'Reinstall\' option in the main menu" << std::endl
        << "5. Try to uninstall the software using the \'Uninstall\' option in the main menu\nThen install it again using the \'Install\' otption in the main menu" << std::endl
        << "6. Try to manually remove th esoftware at the installed location and then install it again using the directions in step 5." << std::endl
        << "7. Open the settings.json file in the \'\' folder and check if the install_path parameter is set and valid\n" << std::endl
        << "If your problem still persists, file an issue using the \'Report error\' option in the main menu" << std::endl;

    std::cout << "Press any key to continue..." << std::endl;
    _getch();
    system("cls");

    return 0;
}

int Menuoptions::Dependencies(void)
{
    std::cout << "Dependency version do not reflect currently installed versions" << std::endl
        << "Thay only specifiy the requirements that the program needs" << std::endl;
    std::cout << "— Python 3.9+ (most recent 3.11) https://www.python.org/downloads/release/python-3114/" << std::endl;
    std::cout << "— Python Install Package packagemanager (pip) (most recent version) https://pypi.org/project/pip/" << std::endl;
    std::cout << "— Selenium PyPI package (most recent version)  https://www.selenium.dev/documentation/webdriver/getting_started/install_library/#pip" << std::endl;
    std::cout << "— Git distributed version control system (Git SCM) (most recent version) https://git-scm.com/download/win" << std::endl;

    std::cout << "Press any key to continue..." << std::endl;
    _getch();
    system("cls");

    return 0;
}

int Menuoptions::About(std::string path)
{
    std::cout << path << std::endl;
    std::ifstream file(path.c_str());
    nlohmann::json parsed_json = nlohmann::json::parse(file);
    std::string install_path = parsed_json["install_path"];
    file.close();

    std::cout << "Installer version: " << "1.1" << std::endl;
    std::cout << "Program installed at: " << install_path << std::endl;
    std::cout << "Installer made by: Balázs Ivánczi" << std::endl;
    std::cout << "Backend development and testing for Chrome: Balázs Ivánczi" << std::endl;
    std::cout << "Backend development and testing for Firefox: Balázs Domonkos" << std::endl;
    std::cout << "GUI and frontend development: Márton Kós" << std::endl;
    std::cout << "Documentation by: Balázs Domonkos" << std::endl;
    std::cout << "Program design by: Balázs Ivánczi and Márton Kós" << std::endl;
    std::cout << "2023 @ Visionsoftware Kft." << std::endl;

    std::cout << "Press any key to continue..." << std::endl;
    _getch();
    system("cls");

    return 0;
}
