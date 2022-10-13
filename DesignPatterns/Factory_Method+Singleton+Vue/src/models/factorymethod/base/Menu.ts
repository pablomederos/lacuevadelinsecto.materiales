export abstract class Menu {

    private _menuOptions: Options[] = new Array<Options>()
    
    public get Options() {
        return this._menuOptions
    }

    protected insertMenuOptions(menuOptions: string[]) {
        menuOptions.forEach(option => {
            this._menuOptions.push(
                {
                    key: option,
                    value: () => {
                        alert(`Hiciste click en la opción ${option}`)
                    }
                }
            )
        })
    }
}

interface Options {
    key: string
    value: Function
}