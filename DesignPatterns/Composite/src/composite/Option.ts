import AbstractOption from './AbstractOption'

export default class Option extends AbstractOption {

    checkbox: HTMLInputElement | undefined
    value: string

    constructor(value: string, callbackSelected: (value: string[], state: boolean) => void) {
        super(callbackSelected)
        this.value = value
    }

    createOptionRow(): HTMLDivElement {

        const row = document.createElement('div')
        row.style.display = 'inline-flex'
        row.style.color = 'green'
        row.classList.add('option')

        this.checkbox = document.createElement('input')
        this.checkbox.type = 'checkbox'
        this.checkbox.onclick = (ev: Event) => {
            const state = (ev.target as HTMLInputElement).checked ?? false
            this.callbackSelected(
                [ this.value ],
                state
            )
        }

        const text = document.createElement('span')
        text.textContent = this.value

        row.appendChild(this.checkbox)
        row.appendChild(text)

        return row
    }

    select(state: boolean): string[] | void {

        if (this.checkbox)
            this.checkbox.checked = state
            
        return Array.of(this.value)
    }

}