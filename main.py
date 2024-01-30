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
    
    """
    So, the reason that we're not using a loop for starting the processes
    Is that this method is unironically 60% faster for some fucking reason
    Not in starting the processes, but their final execution
    Why? I have no fucking clue

    So, we have an abomination of a Process in Core.CreateDriverProcesses
    That is a really ugly solution but this is to prevent indexing out of the list
    It's a Process that points to a function doing literally fucking nothing
    """
    print(f"Host PID:", getpid())
    for p in processes:
        p.start()
    print("Host Finished")