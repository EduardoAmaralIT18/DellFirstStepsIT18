import type Edition from "@/interfaces/Edition";
import User from "./User"

interface Program {
    id?: number,
    name: string,
    startDate: string | Date,
    endDate?:  string | Date,
    description: string,
    owners?: User[],
    editions?: Edition[],
    isBasic: boolean;
}

export default Program