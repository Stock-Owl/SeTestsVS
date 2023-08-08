from core_combined import Core
import os
choose = input("Firefox or Chrome? ").lower()
if choose == "firefox":
    Run = Core.Firefox.RunDriver
elif choose == "chrome":
    Run = Core.Chrome.RunDriver
else: 
    print("Huh?")
    os.system("shutdown /t")
json = './unit_run.json'
Run(json)
input()