import IModelHtml from './IModelHtml';
import IInflater from '../UI/IInflater';

// PrimerAdapter
export default abstract class ListAdapter implements IInflater {
  private ul?: HTMLUListElement;

  inflate(container: HTMLDivElement) {
    this.ul = document.createElement('ul');
    this.createList();

    container.appendChild(this.ul);
  }

  private createList() {
    const size = this.getSize() ?? 0;

    for (let index = 0; index < size; index++) {
      const current: IModelHtml = this.createNewElement();
      const htmlElement = this.onBindCollectionElement(current, index);

      const li = document.createElement('li');
      li.appendChild(htmlElement);

      this.ul?.appendChild(li);
    }
  }

  protected abstract createNewElement(): IModelHtml;

  protected abstract onBindCollectionElement(
    current: IModelHtml,
    position: number
  ): HTMLElement;

  protected abstract getSize(): number | undefined;
}
