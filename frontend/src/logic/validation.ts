export function validateEmail(e: string): boolean {
    var re = /\S+@\S+\.\S+/;
    return re.test(e);
}
