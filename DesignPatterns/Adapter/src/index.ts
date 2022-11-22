import ListStringBuidler from './Caso1/ListStringBuilder';
import ListBuilderAdapter from './Caso2/ListBuilderAdapter';
import Persona from './Caso3/Persona';
import PersonasToHTMLList from './Caso3/PersonasToHTMLList';
import IInflater from './UI/IInflater';
import Ui from './UI/UI';

const ui = new Ui();

let inflater: IInflater;

/**
 * Caso 1
 *
 * Clase encargada de alimentar un html con una lista de textos
 */
// const elements: string[] = ['elemento 1', 'elemento 2', 'elemento 3'];

// inflater = new ListStringBuidler(elements); // List String Builder

/**
 * Caso 2
 *
 * Adaptador sencillo
 * Clase encargada de crear una lista de listas de textos
 */
// const elements: string[] = ['elemento 1', 'elemento 2', 'elemento 3']

// const listOfLists: ListStringBuidler[] = [
//   new ListStringBuidler(elements),
//   new ListStringBuidler(elements),
//   new ListStringBuidler(elements)
// ]

// inflater = new ListBuilderAdapter(
//   listOfLists
// ) // List Builder

/**
 * Caso 3
 *
 * Adaptador complejo para reducir código repetido
 */


inflater = new PersonasToHTMLList(
  {
    nombre: 'Pablo',
    apellido: 'Mederos',
  },
  {
    nombre: 'Gabriel',
    apellido: 'Mederos',
  }
);


// No comentar
ui.createApp(inflater); // Create App
