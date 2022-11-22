import ListStringBuidler from '../Caso1/ListStringBuilder';
import IInflater from '../UI/IInflater';

// PrimerAdapter
export default class ListBuilderAdapter implements IInflater {
  private ol: HTMLOListElement;
  private elements: ListStringBuidler[];

  constructor(elements: ListStringBuidler[]) {
    this.ol = document.createElement('ol');
    this.elements = elements;
  }

  inflate(container: HTMLDivElement) {
    this.elements?.forEach((el) => {
      const li = document.createElement('li');

      const div = document.createElement('div');
      div.classList.add('ol-container');

      el.inflate(div);

      li.appendChild(div);
      this.ol.appendChild(li);
    });

    container.appendChild(this.ol);
  }
}
