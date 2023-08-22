from selenium.webdriver.chrome.webdriver import WebDriver as ChromeDriver
from selenium.webdriver.firefox.webdriver import WebDriver as FirefoxDriver
from selenium.common.exceptions import JavascriptException as SeJSException

class Support:
    from os.path import exists

    def ClearAllLogs(path_: str) -> None:
        paths: list[str] = [
            f"{path_}/run.log",
            f"{path_}/process.log",
            f"{path_}/../js.log",
            f"{path_}/error.log"]
        
        for file in paths:
            with open(file, mode='w', encoding='utf-8') as f:
                f.write("")

    def LogAll(path_: str, log_line: str, time_disabled: bool = False) -> None:
        from datetime import datetime as dt

        path = f"{path_}/run.log"

        try:
            assert Support.exists(path)
        except AssertionError:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")

        with open(path, "a", encoding="utf-8") as f:
            if not time_disabled:
                time_: str = dt.now().time().strftime("/%H:%M:%S:%f/ ")
                f.write(time_)
            f.write(log_line)

    def LogJS(
            path_: str,
            log_JS_args: dict[str, str | list | int | bool | None],
            log: str | SeJSException,
            terminal_mode = False,
            time_disabled: bool = False,
            index: int | None = None) -> None:
        from time import sleep
        

        path: str = f"{path_}/js.log"
        fuckup: int | float = log_JS_args['retry_timeout']  / 1000

        try:
            assert Support.exists(path)
        except FileNotFoundError:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")

        # type checking required in both terminal and normal mode
        # because exception logging requires a different log line
        if terminal_mode:
            if isinstance(log, SeJSException):
                stacktrace = "\n".join(log.stacktrace)
                with open(path, 'a+', encoding='utf-8') as f:
                    if index is not None:
                        to_write = f"{index} ❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                    else:
                        to_write = f"❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                    f.write(to_write)
                    Support.LogAll(path_, to_write, time_disabled = time_disabled)
            elif isinstance(log, str):
                with open(path, mode ='a+', encoding='utf-8') as f:
                    if index is not None:
                        to_write = f"{index} ❗ JavaScript:\\n{log}\n"
                    else:
                        to_write = f"❗ JavaScript:\\n{log}\n"
                    f.write(to_write)
                    Support.LogAll(path_, to_write, time_disabled = time_disabled)
            else: raise ValueError("LogJS takes either a string or a selenium.common.exceptions.JavascriptException as an argument")

        else:
            while True:
                with open(path, mode = 'r', encoding = "utf-8") as f:
                    contents: str = f.read()
                if contents != '':
                    sleep(fuckup)
                    continue
                else:
                    if isinstance(log, SeJSException):
                        stacktrace = "\n".join(log.stacktrace)
                        if index is not None:
                            to_write: str = f"{index} ❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                        else:
                            to_write: str = f"❗ JavaScript:\n{log.msg}\nSteack Trace:\n{stacktrace}\n"
                        with open(path, mode ='a+', encoding='utf-8') as f:
                            f.write(to_write)
                            Support.LogAll(path_, to_write, time_disabled = time_disabled)
                        break
                    elif isinstance(log, str):
                        with open(path, mode ='a+', encoding='utf-8') as f:
                            to_write = f"❗ JavaScript:\\n{log}\n"
                            f.write(to_write)
                            Support.LogAll(path_, to_write, time_disabled = time_disabled)
                        break
                    else: raise ValueError("LogJS takes either a string or a selenium.common.exceptions.JavascriptException as an argument")
        
    def AutoLogJS(
            driver: ChromeDriver | FirefoxDriver,
            path_: str,
            log_JS_args: dict[str, str | list | int | bool | None],
            terminal_mode: bool = False,
            time_disabled: bool = False) -> None:
        from time import sleep
        """
        Appends the current JavaScript Console Logs to the end of the file.
        In return, we should get an empty file.
        An empty file means that the other process has used the console logs,
        and finished all tasks with the file. AKA the file is safe to write in.

        Args:
            * (bool) active: wether the Logging process is active or not. (does it write to the output file?)
            * (str) path: path to the log file
            * (int) refresh_rate: the amout of time (in ms) the program waits before trying to update the logs
            * (int) retry_timeout: the amout of time (in ms) the program waits before trying to write the logs (if the file was still in use)
        """

        path: str = f"{path_}/js.log"
        mimir: int | float = log_JS_args['refresh_rate']    / 1000
        fuckup: int | float = log_JS_args['retry_timeout']  / 1000

        assert log_JS_args['active'], "auto JavaScript logging is off"
        try:
            assert Support.exists(path)
        except:
            with open(path, mode='w', enocoding='utf-8') as f:
                f.write("")

        processed: list[str] = []

        while True:
            browser_logs = driver.get_log("browser")
            # shared vairable needs to be implemented

            # inner whiles ensures that the autolog will not exit until all the logs are processed
            # it only breaks the inner loops after the logs are processed and it didn't fuck up
            if terminal_mode:
                while True:
                    with open(path, mode = 'a+', encoding = 'utf-8') as f:
                        for i in range(len(browser_logs)):
                            log = browser_logs[i]
                            if log in processed:
                                continue
                            # The reason it's processed with {i} and printed as such
                            # is that no identical logs can exist in `processed`
                            log_line = \
                            f"{i} ❗ JavaScript:\n{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}\n#\n"
                            f.write(log_line)
                            Support.LogAll(path = path_, log_line = log_line, time_disabled=time_disabled)
                            processed.append(log_line)
                    break
                sleep(mimir)

            else:
                while True:
                    with open(path, mode = 'r+', encoding = 'utf-8') as f:
                        contents = f.read()
                    if contents != '':
                        sleep(fuckup)
                        continue
                    else:
                        with open(path, mode = 'a+', encoding = 'utf-8') as f:
                            for i in range(len(browser_logs)):
                                log = browser_logs[i]
                                if log in processed:
                                    continue
                                # The reason it's processed with {i} and printed as such
                                # is that no identical logs can exist in `processed`
                                log_line = \
                                f"{i} ❗ JavaScript:\n{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}\n#\n"
                                f.write(log_line)
                                Support.LogAll(path = path_, log_line = log_line, time_disabled=time_disabled)
                                processed.append(log_line)
                        break
                sleep(mimir)

    def LogProc(path_: str, log_line: str, time_disabled: bool = False) -> None:
        
        path = f"{path_}/process.log"

        try:
            assert Support.exists(path)
        except:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")
        
        log_line = f"✅ DONE: {log_line}\n"
        with open(path, mode='a+', encoding='utf-8') as f:
            f.write(log_line)
        Support.LogAll(path_, log_line, time_disabled=time_disabled)

    def LogError(path_: str, log_line: str,  time_disabled: bool = False) -> None:

        path = f"{path_}/error.log"

        try:
            assert Support.exists(path)
        except:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")

        log_line = f"{log_line}\n"
        with open(path, mode='a+', encoding='utf-8') as f:
            f.write(log_line)
        Support.LogAll(path_, log_line, time_disabled=time_disabled)
