import IInflater from "../UI/IInflater";

export default class ListStringBuidler implements IInflater {

  private elements: string[]
  private ul: HTMLUListElement

  constructor(elements: string[]) {
    this.ul = document.createElement('ul')
    this.elements = elements
  }

  inflate(container: HTMLDivElement) {
    
    this.elements?.forEach( el => {
      const li = document.createElement('li')
      li.innerText = el
      this.ul.appendChild(li)
    })

    container.appendChild(this.ul)
  }

}