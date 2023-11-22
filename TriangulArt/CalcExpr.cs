
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TriangulArt {
	public class MathParser {
		private const string NumberMaker = "#";
		private const string OperatorMarker = "$";
		private const string FunctionMarker = "@";
		private const string Plus = OperatorMarker + "+";
		private const string UnPlus = OperatorMarker + "un+";
		private const string Minus = OperatorMarker + "-";
		private const string UnMinus = OperatorMarker + "un-";
		private const string Multiply = OperatorMarker + "*";
		private const string Divide = OperatorMarker + "/";
		private const string Degree = OperatorMarker + "^";
		private const string LeftParent = OperatorMarker + "(";
		private const string RightParent = OperatorMarker + ")";
		private const string Sqrt = FunctionMarker + "sqrt";
		private const string Sin = FunctionMarker + "sin";
		private const string Cos = FunctionMarker + "cos";
		private const string Tg = FunctionMarker + "tg";
		private const string Ctg = FunctionMarker + "ctg";
		private const string Sh = FunctionMarker + "sh";
		private const string Ch = FunctionMarker + "ch";
		private const string Th = FunctionMarker + "th";
		private const string Log = FunctionMarker + "log";
		private const string Ln = FunctionMarker + "ln";
		private const string Exp = FunctionMarker + "exp";
		private const string Abs = FunctionMarker + "abs";

		private readonly Dictionary<string, string> supportedOperators = new Dictionary<string, string>
			{
				{ "+", Plus },
				{ "-", Minus },
				{ "*", Multiply },
				{ "/", Divide },
				{ "^", Degree },
				{ "(", LeftParent },
				{ ")", RightParent }
			};

		private readonly Dictionary<string, string> supportedFunctions = new Dictionary<string, string>
			{
				{ "sqrt", Sqrt },
				{ "√", Sqrt },
				{ "sin", Sin },
				{ "cos", Cos },
				{ "tg", Tg },
				{ "ctg", Ctg },
				{ "sh", Sh },
				{ "ch", Ch },
				{ "th", Th },
				{ "log", Log },
				{ "exp", Exp },
				{ "abs", Abs }
			};

		private int ang = 0;

		private readonly Dictionary<string, string> supportedConstants = new Dictionary<string, string>
			{
				{"pi", NumberMaker +  Math.PI.ToString() },
				{"e", NumberMaker + Math.E.ToString() },
				{"ang", NumberMaker + "ang" }
			};

		private readonly char decimalSeparator;
		private bool isRadians;

		public MathParser() {
			try {
				decimalSeparator = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
			}
			catch (FormatException ex) {
				throw new FormatException("Error: can't read char decimal separator from system, check your regional settings.", ex);
			}
		}

		public MathParser(char decimalSeparator) {
			this.decimalSeparator = decimalSeparator;
		}

		public double Parse(string expression, int valAng, bool isRadians = true) {
			this.isRadians = isRadians;
			ang = valAng;
			try {
				return Calculate(ConvertToRPN(FormatString(expression)));
			}
			catch (DivideByZeroException e) {
				throw e;
			}
			catch (FormatException e) {
				throw e;
			}
			catch (InvalidOperationException e) {
				throw e;
			}
			catch (ArgumentOutOfRangeException e) {
				throw e;
			}
			catch (ArgumentException e) {
				throw e;
			}
			catch (Exception e) {
				throw e;
			}
		}

		private string FormatString(string expression) {
			if (string.IsNullOrEmpty(expression))
				throw new ArgumentNullException("Expression is null or empty");

			StringBuilder formattedString = new StringBuilder();
			int balanceOfParenth = 0; // Check number of parenthesis
			for (int i = 0; i < expression.Length; i++) {
				char ch = expression[i];
				if (ch == '(')
					balanceOfParenth++;
				else if (ch == ')')
					balanceOfParenth--;

				if (char.IsWhiteSpace(ch))
					continue;
				else if (char.IsUpper(ch))
					formattedString.Append(char.ToLower(ch));
				else
					formattedString.Append(ch);
			}

			if (balanceOfParenth != 0)
				throw new FormatException("Number of left and right parenthesis is not equal");

			return formattedString.ToString();
		}

		private string ConvertToRPN(string expression) {
			int p = 0; // Current position of lexical analysis
			StringBuilder outputString = new StringBuilder();
			Stack<string> stack = new Stack<string>();

			while (p < expression.Length) {
				string token = LexicalAnalysisInfixNotation(expression, ref p);
				outputString = SyntaxAnalysisInfixNotation(token, outputString, stack);
			}

			while (stack.Count > 0) {
				if (stack.Peek()[0] == OperatorMarker[0])
					outputString.Append(stack.Pop());
				else
					throw new FormatException("Format exception, there is function without parenthesis");
			}
			return outputString.ToString();
		}

		private string LexicalAnalysisInfixNotation(string expr, ref int p) {
			StringBuilder token = new StringBuilder();
			token.Append(expr[p]);
			if (supportedOperators.ContainsKey(token.ToString())) {
				bool isUnary = p == 0 || expr[p - 1] == '(';
				p++;
				switch (token.ToString()) {
					case "+":
						return isUnary ? UnPlus : Plus;
					case "-":
						return isUnary ? UnMinus : Minus;
					default:
						return supportedOperators[token.ToString()];
				}
			}
			else if (char.IsLetter(token[0]) || supportedFunctions.ContainsKey(token.ToString()) || supportedConstants.ContainsKey(token.ToString())) {

				while (++p < expr.Length && char.IsLetter(expr[p])) {
					token.Append(expr[p]);
				}

				if (supportedFunctions.ContainsKey(token.ToString()))
					return supportedFunctions[token.ToString()];
				else if (supportedConstants.ContainsKey(token.ToString()))
					return supportedConstants[token.ToString()];
				else
					throw new ArgumentException("Unknown token");
			}
			else if (char.IsDigit(token[0]) || token[0] == decimalSeparator) {
				if (char.IsDigit(token[0])) {
					while (++p < expr.Length && char.IsDigit(expr[p])) {
						token.Append(expr[p]);
					}
				}
				else
					token.Clear();

				if (p < expr.Length && expr[p] == decimalSeparator) {
					token.Append(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					while (++p < expr.Length && char.IsDigit(expr[p])) {
						token.Append(expr[p]);
					}
				}
				if (p + 1 < expr.Length && expr[p] == 'e' && (char.IsDigit(expr[p + 1]) || (p + 2 < expr.Length && (expr[p + 1] == '+' || expr[p + 1] == '-') && char.IsDigit(expr[p + 2])))) {
					token.Append(expr[p++]); // e
					if (expr[p] == '+' || expr[p] == '-')
						token.Append(expr[p++]); // sign

					while (p < expr.Length && char.IsDigit(expr[p])) {
						token.Append(expr[p++]); // power
					}
					return NumberMaker + Convert.ToDouble(token.ToString());
				}

				return NumberMaker + token.ToString();
			}
			else
				throw new ArgumentException("Unknown token in expression");
		}

		private StringBuilder SyntaxAnalysisInfixNotation(string token, StringBuilder outputString, Stack<string> stack) {
			if (token[0] == NumberMaker[0]) {
				outputString.Append(token);
			}
			else if (token[0] == FunctionMarker[0]) {
				stack.Push(token);
			}
			else if (token == LeftParent) {
				stack.Push(token);
			}
			else if (token == RightParent) {

				string elem;
				while ((elem = stack.Pop()) != LeftParent) {
					outputString.Append(elem);
				}

				if (stack.Count > 0 && stack.Peek()[0] == FunctionMarker[0]) {
					outputString.Append(stack.Pop());
				}
			}
			else {
				while (stack.Count > 0 && Priority(token, stack.Peek())) {
					outputString.Append(stack.Pop());
				}
				stack.Push(token);
			}
			return outputString;
		}

		private bool Priority(string token, string p) {
			return IsRightAssociated(token) ? GetPriority(token) < GetPriority(p) : GetPriority(token) <= GetPriority(p);
		}

		private bool IsRightAssociated(string token) {
			return token == Degree;
		}

		private int GetPriority(string token) {
			switch (token) {
				case LeftParent:
					return 0;
				case Plus:
				case Minus:
					return 2;
				case UnPlus:
				case UnMinus:
					return 6;
				case Multiply:
				case Divide:
					return 4;
				case Degree:
				case Sqrt:
					return 8;
				case Sin:
				case Cos:
				case Tg:
				case Ctg:
				case Sh:
				case Ch:
				case Th:
				case Log:
				case Ln:
				case Exp:
				case Abs:
					return 10;
				default:
					throw new ArgumentException("Unknown operator");
			}
		}

		private double Calculate(string expression) {
			int p = 0;
			var stack = new Stack<double>(); // Contains operands
			while (p < expression.Length) {
				string token = LexicalAnalysisRPN(expression, ref p);
				stack = SyntaxAnalysisRPN(stack, token);
			}
			if (stack.Count > 1)
				throw new ArgumentException("Excess operand");

			return stack.Pop();
		}

		private string LexicalAnalysisRPN(string expr, ref int p) {
			StringBuilder token = new StringBuilder();
			token.Append(expr[p++]);
			while (p < expr.Length && expr[p] != NumberMaker[0] && expr[p] != OperatorMarker[0] && expr[p] != FunctionMarker[0]) {
				token.Append(expr[p++]);
			}
			return token.ToString();
		}

		private Stack<double> SyntaxAnalysisRPN(Stack<double> stack, string token) {
			if (token[0] == NumberMaker[0]) {
				if (token == "#ang")
					stack.Push(ang);
				else
					stack.Push(double.Parse(token.Remove(0, 1)));
			}
			else if (NumberOfArguments(token) == 1) {
				double arg = stack.Pop();
				double rst;

				switch (token) {
					case UnPlus:
						rst = arg;
						break;
					case UnMinus:
						rst = -arg;
						break;
					case Sqrt:
						rst = Math.Sqrt(arg);
						break;
					case Sin:
						rst = ApplyTrigFunction(Math.Sin, arg);
						break;
					case Cos:
						rst = ApplyTrigFunction(Math.Cos, arg);
						break;
					case Tg:
						rst = ApplyTrigFunction(Math.Tan, arg);
						break;
					case Ctg:
						rst = 1 / ApplyTrigFunction(Math.Tan, arg);
						break;
					case Sh:
						rst = Math.Sinh(arg);
						break;
					case Ch:
						rst =
						rst = Math.Cosh(arg);
						break;
					case Th:
						rst = Math.Tanh(arg);
						break;
					case Ln:
						rst = Math.Log(arg);
						break;
					case Exp:
						rst = Math.Exp(arg);
						break;
					case Abs:
						rst = Math.Abs(arg);
						break;
					default:
						throw new ArgumentException("Unknown operator");
				}
				stack.Push(rst);
			}
			else {
				double arg2 = stack.Pop();
				double arg1 = stack.Pop();
				double rst;
				switch (token) {
					case Plus:
						rst = arg1 + arg2;
						break;
					case Minus:
						rst = arg1 - arg2;
						break;
					case Multiply:
						rst = arg1 * arg2;
						break;
					case Divide:
						if (arg2 == 0)
							throw new DivideByZeroException("Second argument is zero");

						rst = arg1 / arg2;
						break;
					case Degree:
						rst = Math.Pow(arg1, arg2);
						break;
					case Log:
						rst = Math.Log(arg2, arg1);
						break;
					default:
						throw new ArgumentException("Unknown operator");
				}
				stack.Push(rst);
			}
			return stack;
		}

		private double ApplyTrigFunction(Func<double, double> func, double arg) {
			if (!isRadians)
				arg = arg * Math.PI / 180; // Convert value to degree

			return func(arg);
		}

		private int NumberOfArguments(string token) {
			switch (token) {
				case UnPlus:
				case UnMinus:
				case Sqrt:
				case Tg:
				case Sh:
				case Ch:
				case Th:
				case Ln:
				case Ctg:
				case Sin:
				case Cos:
				case Exp:
				case Abs:
					return 1;
				case Plus:
				case Minus:
				case Multiply:
				case Divide:
				case Degree:
				case Log:
					return 2;
				default:
					throw new ArgumentException("Unknown operator");
			}
		}
	}
}