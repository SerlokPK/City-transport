export class Schedule {
    DirectionA: any[] = [];
    DirectionB: any[] = [];

    constructor(schedule: Schedule) {
        this.DirectionA = schedule.DirectionA;
        this.DirectionB = schedule.DirectionB;
    }
}
