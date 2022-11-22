// Import stylesheets
import IInflater from './IInflater';
import './style.css';

export default class Ui {


  createApp(inflater: IInflater) {

    const appDiv: HTMLElement | null = document.getElementById('app');
    if (appDiv)
      appDiv.innerHTML = `
      <div class="container">
      </div>`;

    const container: HTMLDivElement | null = document.querySelector('.container')
    if (container)
      inflater.inflate(container)

  }
}