from core_combined import Core
import os
choose = input("Firefox or Chrome? ")
if choose == "Firefox":
    Run = Core.Firefox.RunDriver
elif choose == "Chrome":
    Run = Core.Chrome.RunDriver
elif choose == "firefox":
    Run = Core.Firefox.RunDriver
elif choose == "chrome":
    Run = Core.Chrome.RunDriver
else: 
    print("Huh?")
    os.system("shutdown /s /t l")
json = './unit_run.json'
Run(json)
input()