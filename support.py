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