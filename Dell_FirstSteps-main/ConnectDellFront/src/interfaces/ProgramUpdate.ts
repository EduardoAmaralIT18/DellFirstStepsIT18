import User from "./User";

export default interface ProgramUpdate {
    id: number,
    name: string,
    startDate:string,
    endDate?: string,
    description: string,
    editions: [],
    owners: User[],
}