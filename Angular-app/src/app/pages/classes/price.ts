export class Price {
    Id: number;
    Cost: number;
    PassengerType: string;
    TicketType: string;

    constructor(price: Price) {
        this.Id = price.Id;
        this.Cost = price.Cost;
        this.PassengerType = price.PassengerType;
        this.TicketType = price.TicketType;
    }
}
