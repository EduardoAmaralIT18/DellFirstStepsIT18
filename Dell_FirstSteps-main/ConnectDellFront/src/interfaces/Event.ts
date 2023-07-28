import User from "./User"
export default interface TypeEvent {
    id : number,
    name : string,
    eventType: number,
    phaseType : number,
    startDate : Date,
    endDate : Date,
    where : string,
    peopleInvolved: User[]
}