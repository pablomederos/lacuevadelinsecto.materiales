export abstract class ResponsabilityHandler {
    protected nextHandler?: ResponsabilityHandler;

    public setNextHandler(nextHandler: ResponsabilityHandler): void {
        this.nextHandler = nextHandler;
    }

    public abstract handle(): void;
}