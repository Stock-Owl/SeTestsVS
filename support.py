from seleniumwire.webdriver import Chrome as ChromeDriver
from selenium.common.exceptions import JavascriptException as SeJSException
from datetime import datetime as dt

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

        path = f"{path_}/run.log"

        try:
            assert Support.exists(path)
        except AssertionError:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")

        with open(path, "a", encoding="utf-8") as f:
            if not time_disabled:
                time_: str = dt.now().time().strftime("/%H:%M:%S:%f/ ")
                f.write(f"{time_} {log_line}")
                return
            f.write(log_line)

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

    def LogJS(
            path_: str,
            retry_timeout: int,
            log: str | SeJSException,
            time_disabled: bool = False,
            index: int | None = None) -> None:
        from time import sleep
        

        path: str = f"{path_}/js.log"
        fuckup: int | float = retry_timeout  / 1000

        try:
            assert Support.exists(path)
        except FileNotFoundError:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")

        # type checking required in both terminal and normal mode
        # because exception logging requires a different log line
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
                            to_write: str = f"{index} ❗ JavaScript:\n{log.msg}\nStack Trace:\n{stacktrace}\n"
                        else:
                            to_write: str = f"❗ JavaScript:\n{log.msg}\nStack Trace:\n{stacktrace}\n"
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
        
    def LogBrowserJSLog(
            driver: ChromeDriver,
            parent_log_path: str,
            log_js_retry_timeout: int,
            time_disabled: bool = False,
            **overflow) -> None:    #overflow not used
        
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
        from time import sleep

        path: str = f"{parent_log_path}/../js.log"
        fuckup: int | float = log_js_retry_timeout / 1000

        try:
            assert Support.exists(path)
        except:
            with open(path, mode='w', encoding='utf-8') as f:
                f.write("")

        browser_logs: list[dict[str, str | int]] = driver.get_log('browser')

        while True:
            print("logger waiting")
            with open(path, mode = 'r+', encoding = 'utf-8') as f:
                contents = f.read()
            if contents != '':
                sleep(fuckup)
                continue

            with open(path, mode = 'a+', encoding = 'utf-8') as f:
                for i in range(len(browser_logs)):
                    log = browser_logs[i]
                    # The reason it's processed with {i} and printed as such
                    # is that no identical logs can exist in `processed`
                    log_line = \
                    f"{i} ❗ JavaScript:\n{log['source']} — {log['level']}:\n{log['message']}\n\t{log['timestamp']}\n#\n"
                    f.write(log_line)
                    Support.LogAll(parent_log_path, log_line, time_disabled=time_disabled)
            break
        
        print("logger finished")
