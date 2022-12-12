import './style.css'
import Option from './composite/Option'
import OptionGroup from './composite/OptionGroup'

const app = document.querySelector<HTMLDivElement>('#app')!
app.style.display = 'flex'
app.style.flexDirection = 'column'

// Puede ser un modelo o una propiedad deseste
const accumulator: string[] = []

// Alimenta el modelo según la interacción del usuario
const selectedOptions = (value: string[], state: boolean) => {

  if (state)
    value.forEach(option => {
      if (!accumulator.includes(option))
        accumulator.push(option)
    })
  else
    value.forEach(option => {
      accumulator.splice(
        accumulator.indexOf(option),
        1
      )
    })

  console.clear()
  console.table('Total Seleccionados: ', accumulator)
}

// Single Option
const singleOption = new Option('Single Option', selectedOptions);
app.appendChild(singleOption.createOptionRow());

(window as any).singleOption = singleOption

// Option Group
const optionGroup = new OptionGroup(
  'Option Group',
  selectedOptions,
  new Option('Option 1', selectedOptions),
  new Option('Option 2', selectedOptions),
  new Option('Option 3', selectedOptions)
)

app.appendChild(optionGroup.createOptionRow())

// Group of Groups with single
const groupOfGroups = new OptionGroup(
  'Group of Groups',
  selectedOptions,
  new OptionGroup(
    'Option Group a gog',
    selectedOptions,
    new Option('Option 1 in a gog', selectedOptions),
    new Option('Option 2 in a gog', selectedOptions),
    new Option('Option 3 in a gog', selectedOptions)
  ),
  new Option('Single Option  a gog', selectedOptions),
)

app.appendChild(groupOfGroups.createOptionRow())