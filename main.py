from core import Core
from os import getpid
from json import loads
from multiprocessing import freeze_support, Process

from core import Core

if __name__ == '__main__':
    freeze_support()
    with open('./run.json', mode='r', encoding='utf-8') as f:
        json_ = loads(f.read())
    processes: list[Process] = Core.CreateDriverProcesses(json_)
    
    print(f"Host PID:", getpid())
    processes[0].start()
    processes[1].start()
    print("Host Finished")