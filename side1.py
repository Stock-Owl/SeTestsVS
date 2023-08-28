from support import Support
from os import getpid
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from selenium.webdriver.firefox.options import Options as FirefoxOptions
from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.chrome.options import Options as ChromeOptions
from traceback import format_exc, format_stack
from actions import Actions

def ChromeExec(
        browser: str = None,
        options: ChromeOptions | FirefoxOptions = None,
        units: dict[str] = None,
        testname: str = None,
        keep_browser_open: bool = None,
        parent_log_path: str = None,
        log_js_retry_timeout: int = None,
        **overflow) -> None:

        print("Chrome PID:", getpid())
        logging_active: bool = False

        if browser == 'chrome':
            driver = ChromeDriver(options = options)  # , service = service
            browser_break_char = 'c'
            logging_active = True

        elif browser == 'firefox':
            driver = FirefoxDriver(options = options, keep_alive=keep_browser_open) # , service = service
            browser_break_char = 'f'
            
        else:
            print(f"Unknown browser {browser}")
            Support.LogError(f"Unknown browser {browser}")
            return None

        # clears the previous log files
        Support.ClearAllLogs(parent_log_path)
        
        active_bindings: list[str] = []
        failed_units: list[str] = []
        
        for  uname, unit in units.items():
            try:
                backup = unit["backup_of"]

                if backup is not None:
                    # if the backup is target failed, then run as normal
                    if backup in failed_units:
                        pass
                    # if the backup target executed, skip the backup
                    else:
                        log_line = f"\'{uname}\' backup skipped because backup target unit sucessfully executed\n"
                        Support.LogProc(parent_log_path, log_line)
                        continue

                # elif, because if it's an inactive backup, it doesn't need to check for bindings
                elif uname in active_bindings:
                    log_line = f"\'{uname}\' skipped because previous unit failed\n"
                    Support.LogProc(parent_log_path, log_line)
                    continue

                actions = unit['actions']
                for aname, action in actions.items():
                    if action["break"]:
                        if logging_active:
                            pass

                        try:
                            with open(f"{parent_log_path}/../file.brk", mode='a+', encoding='utf-8') as f:
                                f.write(f"{browser_break_char}:{uname}:{aname}\n")

                        except FileNotFoundError:
                            with open(f"{parent_log_path}/../file.brk", mode='w', encoding='utf-8') as f:
                                f.write(f"{browser_break_char}:{uname}:{aname}\n")

                        isempty: bool = False
                        while not isempty:
                            with open(f"{parent_log_path}/../file.brk", mode='r', encoding='utf-8') as f:
                                content: str = f.read()
                                if content == '':
                                    break
                                else:
                                    pass

                        Support.LogProc(parent_log_path, "Breakpoint")

                    match action["type"]:
                        case "goto":
                            url = action["url"]
                            Actions.Goto(driver, url)
                        case "back":
                            Actions.Back(driver)
                        case "forward":
                            Actions.Forward(driver)
                        case "refresh":
                            Actions.Refresh(driver)
                        case "js_execute":
                            commands = action["commands"]
                            Actions.ExecuteJS(driver, commands, path=parent_log_path, retry_timeout=log_js_retry_timeout)
                        case "wait":
                            time = action['amount']
                            Actions.Wait(driver, time)
                        case "wait_for":
                            Actions.WaitFor(driver, action)
                        case "click":
                            Actions.ElementAction(
                                driver,
                                action = 'click',
                                locator = action['locator'],
                                value = action['value'],
                                isSingle = action['single'],
                                isDisplayed = action['displayed'],
                                isEnabled = action['enabled'],
                                isSelected = action['selected'])
                        case "send_keys":
                            Actions.ElementAction(
                                driver,
                                action = 'send_keys',
                                locator = action['locator'],
                                value = action['value'],
                                keys = action['keys'],
                                isSingle = action['single'],
                                isDisplayed = action['displayed'],
                                isEnabled = action['enabled'],
                                isSelected = action['selected'])
                        case "clear":
                            Actions.ElementAction(
                                driver,
                                action = 'clear',
                                locator = action['locator'],
                                value = action['value'],
                                isSingle = action['single'],
                                isDisplayed = action['displayed'],
                                isEnabled = action['enabled'],
                                isSelected = action['selected'])
                        case _:
                            action_type = action['type']
                            Support.LogProc(parent_log_path, f"Unknown action \'{action_type}\'")

                    log_line = f"[U:{uname}][A:{aname}] of type \'{action['type']}\' successfully executed"
                    Support.LogProc(parent_log_path, log_line)

            except:
                bindings = unit['bindings']
                if bindings is not None:
                    if isinstance(bindings, list):
                        for binding in bindings:
                            if isinstance(binding, str):
                                active_bindings.append(binding)
                            else:
                                # wrong element type in string list
                                Support.LogError(parent_log_path, f"Parameters in \'bindings\' must be of type str (string) not {type(binding)}")

                    elif isinstance(bindings, str):
                        active_bindings.append(bindings)

                    else:
                        # wrong elmement type for `bindings` (should be string)
                        Support.LogError(parent_log_path, f"Parameter \'bindings\' must be of type str (string) not {type(bindings)}")

                failed_units.append(uname)
                Support.LogError(parent_log_path, f"Unit \"{uname}\"  failed")

                Support.LogError(parent_log_path, "❌ ERROR:\n----------------------------------------------------------------\n")
                Support.LogError(parent_log_path, f"{format_exc()}Stack:\n", time_disabled=True)

                stack = format_stack()
                # -1 to exclude this expression from stack
                for x in range(len(stack)-1):
                    stack_parts = stack[x].split('\n')
                    origin = stack_parts[0]
                    root = stack_parts[1]
                    Support.LogError(parent_log_path, f"\t[{x}] ORIGIN:\t{origin}\n\t[{x}] ROOT: {root}\t", time_disabled=True)
                Support.LogError(parent_log_path, "----------------------------------------------------------------\n", time_disabled=True)

        if logging_active:
            pass

        if not keep_browser_open:
            driver.quit()

        from datetime import date as d
        today: str = d.today().strftime("%Y-%m-%d")
        # ltlogs = long term logs
        path = f"{parent_log_path}/ltlogs/{today}.log"

        # this path doesn't need type checking, because
        # it must have been created at the start of the runtime for loop
        # and therefore it must exist
        current_log_path = f"{parent_log_path}/run.log"            
        with open(current_log_path, mode='r', encoding='utf-8') as f:
            current_log: str = f.read()

        # try to append to the log file
        try:
            with open(path, mode='r', encoding='utf-8') as f:
                f.read()
            with open(path, mode='a', encoding='utf-8') as f:
                to_write = \
                f"-------------------------------------\n\n{testname}\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        # if the path doesn't exist, create it and log the current date at the top of it
        except FileNotFoundError:
            with open(path, mode='w', encoding='utf-8') as f:
                to_write = \
                f"DATE: {today}\n-------------------------------------\n\n{testname}\n{current_log}\n-------------------------------------\n"
                f.write(to_write)

        print("Chrome finished")
