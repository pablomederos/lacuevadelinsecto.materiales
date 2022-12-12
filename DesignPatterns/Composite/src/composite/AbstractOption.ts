export default abstract class AbstractOption {

    protected callbackSelected: (value: string[], state: boolean) => void;

    constructor(callbackSelected: (value: string[], state: boolean) => void) {
        this.callbackSelected = callbackSelected
    }
    abstract createOptionRow(): HTMLDivElement

    abstract select(state: boolean): string[] | void
}