# List of available WaitFor conditions

All conditions type correspond to the `type` parameter in **JSON** in all lowercase

---

#### Loaded

Checks if the given element has been loaded.

Params (all params are type `string`):

* `locator`: `xpath` or `css_selector`
* `value`: value to be searched and waited for

```json
{
	"type": "loaded",
	"locator": "xpath",
	"value": "xpath to be searched and waited for"
}
```

---

#### Visible

Checks if the given element is visible on the page

Params (all params are type `string`):

* `locator`: `xpath` or `css_selector`
* `value`: value to be searched and waited for

```json
{
	"type": "visible",
	"locator": "xpath",
	"value": "xpath to be searched and waited for"
}
```

---

#### Title_is

Checks if the title of the page is equal to the given value

Params:

* `case_sensitive` (`bool`): `true` or `false `
  If the boolean value is set to false, then the title matching in any case will evaliuate to true
* `title` (`string`): value to compare the page's title to

```json
{
	"type": "title_is",
	"case_sensitive": true,	// YouTube == youtube -> false
	"title": "title to match"
},

{
	"type": "title_is",
	"case_sensitive": false, // YouTube == youtube -> true
	"title": "title to match"
}
```

---

#### Title_contains

Checks if the title of the page contains the given value literally

Params:

* `case_sensitive` (`bool`): `true` or `false `
  If the boolean value is set to false, then the title matching in any case will evaliuate to true
* `title` (`string`): value to check for in the page's title

```json
{
	"type": "title_contains",
	"case_sensitive": true,	// YouTube == youtube -> false
	"title": "title to match"
	// e.g.: "official" in "The official website for european football | UEFA.com" -> true
},

{
	"type": "title_contains",
	"case_sensitive": false, // YouTube == youtube -> true
	"title": "title to match"
}
```

---

#### Url_is

Checks if the URL of the page is equal to the given value
The given value **HAS** to include a protocol or IP used to access the site, such as:

* `http://`
* `https://`
* `localhost://`
* `172.0.0.1://`
* etc.

Params (all params are type `string`):

* `url`: the literal URL to be checked

```json
{
	"type": "url_is",
	"url": "url to check WITH PROTOCOL PREFIXED"
	// e.g.:
	// youtube.com -> invalid, will result in error
	// https://youtube.com -> valid
}
```

---

#### Url_contains

Checks ifthe URL of the page contains a given string literal
The URL checked includes the protocol or IP used to access the site, such as:

* `http://`
* `https://`
* `localhost://`
* `172.0.0.1://`
* etc.

Params (all params are type `string`):

* `url`: the literal URL to be checked

```json
// checks if the page is using a .com domain extension
{
	"type": "url_contains",
	"url": ".com"
},

// checks if the page is using HTTP
{
	"type": "url_contains",
	"url": "http://"
}
```

---

#### Alert_present

Checks if there is an alert present in the browser (JavaScript alert)

Params (all params are type `bool`):

* `present`: specifies if there should or shouldn't be an alert

```json
// returns true if there is an alert present
{
	"type": "alert_present",
	"present": true
}

// returns false if there isn't an alert present
{
	"type": "alert_present",
	"present": false
}
```
