import User from "./User"

interface Program {
    id?: number
    name: string,
    startDate: string | Date,
    endDate?:  string | Date,
    description: string,
    owners?: User[]
}

export default Program