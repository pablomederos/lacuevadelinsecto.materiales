import AbstractOption from "./AbstractOption";

export default class OptionGroup extends AbstractOption {

    checkbox: HTMLInputElement | undefined
    value: string
    options: AbstractOption[]

    constructor(
        value: string,
        callbackSelected: (value: string[], state: boolean) => void,
        ...options: AbstractOption[]
    ) {
        super(callbackSelected)
        this.value = value
        this.options = options
    }

    createOptionRow(): HTMLDivElement {

        const row = document.createElement('div')
        row.style.display = 'flex'
        row.style.flexDirection = 'column'
        row.classList.add('option-group')

        const titleRow = document.createElement('div')
        const titleRowStyle = titleRow.style
        titleRowStyle.display = 'flex'
        titleRow.style.color = 'red'

        this.checkbox = document.createElement('input')
        this.checkbox.type = 'checkbox'
        this.checkbox.onclick = (ev) => this.select(
            (ev.target as HTMLInputElement).checked
        )

        const text = document.createElement('span')
        text.textContent = this.value

        titleRow.appendChild(this.checkbox)
        titleRow.appendChild(text)

        row.appendChild(titleRow)

        if (this.options?.length)
            this.options?.forEach(
                (option: AbstractOption) =>
                    row.appendChild(option.createOptionRow())
            )

        return row
    }

    select(state: boolean): string[] | void {

        if (this.checkbox)
            this.checkbox.checked = state
            
        var result = this.options?.map( // Creo la lista
            option => (option.select(state) as string[])?.[0]
        )
            .filter( // Saco nulos, vacíos o indefinidos
                option => option
            )
        this.callbackSelected(result as [] ?? [], state)
    }

}