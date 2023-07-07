# SeTestsVS

Automated Selenium tests for web (VS)

### Options

---

**Page Load Startegy**:

Default: normal

* normal
* eager
* none

**Accept Insecure Certs**:
Boolean (true/false)
Not case sensitive
Default: false

**Timeouts** (in milliseconds):

Default: pageLoad (default value)

* pageLoad: default 300,000
* script: default 30,000
* implicit: default 0

**Unhandled prompt behavior**:

Default: dismiss and notify

* dismiss
* accept
* dismiss and notify
* accept and notify
* ignore

**Keep browser open**:
Boolean (true/false)
Default: true

### Actions

---

**goto**:

1 parameter: `url`
Navigates to the specified URL

The URL **must** contain the Protocol (`https://` etc.)
For example:

    Valid:`"https://google.com"`
    Invalid: `"google.com"`

**find element**:

2 parameters: `locator`, `value`
`locator` specifies what element attribute to locate / what type of attribute to search for

Available locators are:

* class_name: get elements by their classname
* css_selector: get elements using CSS-style selectors
  For example:
  * `#id1` — finds the elements with the `id1` id
  * `.center` — finds the elements with the `center` class
  * `div.menu` — finds the `div` elements with the `menu` class
  * And so on...
* id: get elements by their id
* name: get elements by their name attribute
* link_text: get link elements by their displayed text
* partial_link_text: get link elements by their displayed text if their displayed text contains the given string
* tag_name: get elements by their HTML tag
* xpath: get elements with an xpath (see [Selenium documentation](https://www.selenium.dev/documentation/webdriver/elements/locators/#xpath))
