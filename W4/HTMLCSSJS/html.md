# HTML_CSS

## HTML
- HyperText Mark-up Language
- NOT a programming language (no if/else, no loop, no variables... etc)
- Defines the structure of the web page

- Elements: Basic building blocks of the web page
    - Elements of interest
      - html
      - head
      - body
      - ... and more
  
    - Semantic Elements: Elements that define the purpose of the section

- Attributes: Further specifies additional info to a tag/element
  - Typically, these are tag specific
  - Global Attributes
    - class
    - id
    - .. and more

- Elements vs Tags
- Self Closing Tags: `<img href="./my-beautiful-cat.jpg">`

#### Weirdly common qc q: Head, Heading, Header?

### Web Accessibility
- [10 Tips on Making your website more accessible](https://webaccess.berkeley.edu/resources/tips/web-accessibility)
- [MDN Doc](https://developer.mozilla.org/en-US/docs/Learn/Accessibility)
- [W3C Intro on Accessibility](https://www.w3.org/WAI/fundamentals/accessibility-intro/)
- [Foundations Course](https://www.w3.org/WAI/fundamentals/foundations-course/)

## CSS
- Cascading Style Sheet
- Also NOT a programming language
- Defines the look of the web page

### Including CSS in your HTML
- Inline: Style attribute
- Internal: Style Tag
- *External*: a separate CSS file through Link tag

- Selectors
  - Target styles to one or more elements
  - Tag
  - Class
  - Id
- Rules
  - The styles themselves
  - Key Value pair

- Advanced Selectors:
  - [Combinator](https://developer.mozilla.org/en-US/docs/Learn/CSS/Building_blocks/Selectors/Combinators)
    - Descendant
    - Child
    - Adjacent sibling 
    - General Sibling 
  - Pseudo-class
  - Pseudo-element

### Applying Styles: Cascading, Inheritance
#### Cascading in CSS
#### Specificity
#### Inheriting Style

### Box Model (common qc question)
- Margin
- Border
- Padding
- Content

### Grid/Flexbox
- Grid: https://cssgridgarden.com/
- Flexbox: https://flexboxfroggy.com/

### Responsive Web Design
This is a design principle that no matter the screen size, the webpages should re-organize themselves to provide good ux(user experience)

### CSS Frameworks
- [Bootstrap](https://getbootstrap.com/)
- [Tailwind CSS](https://tailwindcss.com/)