# TimeGuard Actions with *JSON*

#### Frontend's tasks

* Insert the specified action(s) at the interval start and end of the given TimeGuard while generating the JSON file
* The name of the object should be the name of the TimeGuard preceded with a `_` and the type of operation (`start` | `end`)
  eg:

  ```json
  // TimeGuard named login
  "login_start":
  {
  	// standard action layout
  	"type": "timeguard_start",
  	"break": false
  	// etc.
  }
  //or
  "login_end":
  {
  	// standard action layout
  	"type": "timeguard_start",
  	"break": false
  	// etc.
  }
  ```
* At the interval start, the action specifies the name of the TimeGuard and the target runtime in ***milliseconds***
* At the interval end, the action only specifies the TimeGuard's name

---

#### Backend

* If any TimeGuard remains running / open after the last action in the test, all remaining will be closed sequentially in order of creation

---

#### TimeGuard Start

Specifies the initialization of a TimeGuard object with a given name

Params:

* `target` (`int`): the target runtime given in ***milliseconds***
* `name` (`string`): the name of the TimeGuard (which will later be referenced)

```json
"login_start":
{
	"type": "timeguard_start",
	"break": false,
	"name": "login",
	"target": 10000	// 10 seconds maximum
}
```

---

#### TimeGuard End

Specifies the termination of a TimeGuard.
After logging the result, the TimeGuard will be freed from memory.
If the referenced TimeGuard isn't in memory / hasn't been initalized, it raises a ***ValueException***

Params (all parameters are type `string`):

* `name`: name of the TimeGuard (to be terminated)

```json
"login_end":
{
	"type": "timeguard_end",
	"break": false,
	"name": "login"
}
```
