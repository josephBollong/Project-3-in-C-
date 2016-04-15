using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils {
    class HelpGlossary {

    private static readonly String CRLF = Environment.NewLine;
	private static readonly String QUOTE = "\"";

	public static readonly String LOGIN_HELP = "This is the LOGIN help page." + CRLF + "This is where the instruction for logging in is found." + CRLF + "Enter Q to close this help screen.";
	public static readonly String CREATE_USER_HELP = "This is the CREATEUSER help page." + CRLF + "This is where create a user account." + CRLF + "Options for this command are the following:" + CRLF + "CREATEUSER " + QUOTE+"USERNAME"+QUOTE+" "+QUOTE+"PASSWORD"+QUOTE+" "+QUOTE+"SCREENNAME" + CRLF + "Enter Q to close this help screen.";
	public static readonly String START_PAGE_HELP = "This is the Start help page." + CRLF + "Here you can login to a valid user account or create one." + CRLF + "Enter LOGIN to login as a user or enter CREATEUSER to create" + CRLF + "a user account and get started.Enter Q to close this help screen.";
	public static readonly String LOGOUT_HELP = "This is the LOGOUT help page." + CRLF + "This is use to log out to make changes to accounts" + CRLF + "There are no options for this command" + CRLF + "Enter Q to close this help screen.";
	public static readonly String REMOVE_USER_HELP = "";
	public static readonly String CREATE_ACCOUNT_HELP = "";
	public static readonly String REMOVE_ACCOUNT_HELP = "";
	public static readonly String SELECT_ACCOUNT_HELP = "";
	public static readonly String DESELECT_ACCOUNT_HELP = "";
	public static readonly String WITHDRAW_HELP = "";
	public static readonly String DEPOSIT_HELP = "";
	public static readonly String HISTORY_HELP = "";
	public static readonly String COMMAND_HELP = "";
    }
}
