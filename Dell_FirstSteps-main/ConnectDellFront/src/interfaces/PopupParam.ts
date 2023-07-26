import type User from "@/interfaces/User";
import type Program from "@/interfaces/Program";

export default interface PopupParam{
    object: User | Program
    action: Function
    text: string
    title: string
}