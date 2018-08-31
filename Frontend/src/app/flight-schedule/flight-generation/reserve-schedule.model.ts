import { WeeklyTimetable } from "./weekly-timetable.model";

export class ReserveSchedule {
    aircraft: string;
    flightNo: string;
    origin:string;
    destination:string;
    startReserveDate:Date;
    endReserveDate:Date;
    weeklyTimetable: WeeklyTimetable[];
}