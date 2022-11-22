import ListAdapter from '../Caso3/ListAdapter';
import IModelHtml from './IModelHtml';
import Persona from './Persona';

export default class PersonasToHTMLList extends ListAdapter {
  private elements: Persona[];

  constructor(...elements: Persona[]) {
    super();

    this.elements = elements;
  }

  protected getSize(): number {
    return this.elements?.length;
  }

  protected createNewElement(): IModelHtml {
    return new MyElement();
  }

  protected onBindCollectionElement(
    current: MyElement,
    position: number
  ): HTMLElement {
    const persona = this.elements[position];

    current.nombre = persona.nombre;
    current.apellido = persona.apellido;

    return current.build();
  }
}

class MyElement implements IModelHtml {
  private _nombre: string = '';
  private _apellido: string = '';
  private _id: number;

  constructor() {
    this._id = Math.floor(Math.random() * 100) + 1;
  }

  public set nombre(value: string) {
    this._nombre = value;
  }

  public set apellido(value: string) {
    this._apellido = value;
  }

  build(): HTMLElement {
    const div = document.createElement('div');

    const body = `
      <h5>Creado con el id ${this._id} </h5>

      <label for="name">Nombre:</label>
      <span name="name">${this._nombre}</span>
      <br>
      <label for="lastName">Apellido:</label>
      <span name="lastName">${this._apellido}</span>
      <hr>
    `;

    div.innerHTML = body;

    return div;
  }
}
