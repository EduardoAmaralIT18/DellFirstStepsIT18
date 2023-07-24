import type Edition from "@/interfaces/Edition";
import User from "./User";

export default interface ProgramInfo {
    name: string,
    startDate:string,
    endDate?: string,
    description: string,
    editions: Edition[],
    owners: User[]
}

