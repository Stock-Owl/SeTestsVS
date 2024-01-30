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
	"tpye": "loaded",
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
	"tpye": "visible",
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
	"tpye": "title_is",
	"case_sensitive": true,	// YouTube == youtube -> false
	"title": "title to match"
},

{
	"tpye": "title_is",
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
	"tpye": "title_contains",
	"case_sensitive": true,	// YouTube == youtube -> false
	"title": "title to match"
	// e.g.: "official" in "The official website for european football | UEFA.com" -> true
},

{
	"tpye": "title_contains",
	"case_sensitive": false, // YouTube == youtube -> true
	"title": "title to match"
}
```

---

#### Url_is

Checks if the URL of the page is equal to the given value

Params (all params are tpye `string`):
