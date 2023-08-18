from core import Core
from json import loads
from multiprocessing import freeze_support, Process
from time import sleep

from core import Core

if __name__ == '__main__':
    freeze_support()
    with open('./run.json', mode='r', encoding='utf-8') as f:
        json_ = loads(f.read())
    processes: list[Process] = Core.CreateDriverProcesses(json_)
    # commented out due to geckodriver fuckery
    # now both driver WILL run at the same time but only the chrome logger will log to the parent log path root
    """
    if len(json_["browsers"]) == 2:
        processes[0].start()
        processes[1].start()
        processes[2].start()
        processes[3].start()
    elif len(json_["browsers"]) == 1:
        processes[0].start()
        processes[1].start()
    else:
        print("Browsers parameter can not be empty")
    """
    
    processes[2].start()
    sleep(2)
    processes[0].start()
    processes[1].start()
    print("done")
