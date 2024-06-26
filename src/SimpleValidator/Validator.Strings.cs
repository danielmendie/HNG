﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;
using System;
using SimpleValidator.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace SimpleValidator
{
    public partial class Validator
    {
        #region " IsNotNullOrEmpty "

        public Validator IsNotNullOrEmpty(string value)
        {
            return IsNotNullOrEmpty("", value);
        }

        public Validator IsNotNullOrEmpty(string name, string value)
        {
            return IsNotNullOrEmpty(name, value, string.Format(MessageContainer.IsNotNullOrEmptyMessage, name));
        }

        public Validator IsNotNullOrEmpty(string name, string value, string message)
        {
            // do the check
            if (value.IsNotNullOrEmpty())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsNotNullOrWhiteSpace "

        public Validator IsNotNullOrWhiteSpace(string value)
        {
            return IsNotNullOrWhiteSpace("", value);
        }

        public Validator IsNotNullOrWhiteSpace(string name, string value)
        {
            return IsNotNullOrWhiteSpace(name, value, string.Format(MessageContainer.IsNotNullOrWhiteSpaceMessage, name));
        }

        public Validator IsNotNullOrWhiteSpace(string name, string value, string message)
        {
            // do the check
            if (value.IsNotNullOrWhiteSpace())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsEmail "

        public Validator IsEmail(string value)
        {
            return IsEmail("", value);
        }

        public Validator IsEmail(string name, string value)
        {
            return IsEmail(name, value, string.Format(MessageContainer.IsEmailMessage, name));
        }

        public Validator IsEmail(string name, string value, string message)
        {
            // do the check
            if (value.IsEmail())
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region "EnsureOnlyDigits"

        public Validator EnsureOnlyDigits(string fieldName, string value)
        {
            return EnsureOnlyDigits(fieldName, value, string.Format("The field '{0}' can only contain digits.", fieldName));
        }

        public Validator EnsureOnlyDigits(string fieldName, string value, string errorMessage)
        {
            if (!string.IsNullOrEmpty(value) && !value.All(char.IsDigit))
            {
                AddError(fieldName, errorMessage);
            }
            return this;
        }

        #endregion

        #region " IsRegex "

        public Validator IsRegex(string value, string exp)
        {
            return IsRegex("", value, exp);
        }

        public Validator IsRegex(string name, string value, string exp)
        {
            return IsRegex(name, value, exp, string.Format(MessageContainer.IsRegexMessage, name));
        }

        public Validator IsRegex(string name, string value, string exp, string message)
        {
            // do the check
            if (value.IsRegex(exp))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsPassword "

        public Validator IsPassword(string value)
        {
            return IsPassword("", value);
        }

        public Validator IsPassword(string name, string value)
        {
            return IsPassword(name, value, string.Format(MessageContainer.IsPasswordMessage, name));
        }

        public Validator IsPassword(string name, string value, string message)
        {
            // do the check
            if (!value.IsPassword())
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region " IsEqualTo "

        public Validator IsMatch(string? value, string? compare)
        {
            return IsMatch("", value, compare);
        }

        public Validator IsMatch(string name, string? value, string? compare)
        {
            return IsMatch(name, value, compare, string.Format(MessageContainer.IsMatchMessage, name));
        }

        public Validator IsMatch(string name, string? value, string? compare, string message)
        {
            if (value == null && compare == null)
            {
                return NoError();
            }
            else if (value == null && compare != null)
            {
                return AddError(name, message);
            }
            else if (value != null && compare == null)
            {
                return AddError(name, message);
            }
            else if (value != null && compare != null)
            {
                if (!value.IsEqualTo(compare))
                {
                    return AddError(name, message);
                }
                else
                {
                    return NoError();
                }
            }
            else
            {
                //should not enter here
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsMinLength "

        public Validator IsMinLength(string? value, int min)
        {
            return IsMinLength("", value, min);
        }

        public Validator IsMinLength(string name, string? value, int min)
        {
            return IsMinLength(name, value, min, string.Format(MessageContainer.IsMinLengthMessage, name, min));
        }

        public Validator IsMinLength(string name, string? value, int min, string message)
        {
            if (value == null)
            {
                return AddError(name, message);
            }

            // do the check
            if (value.IsMinLength(min))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsMaxLength "

        public Validator IsMaxLength(string value, int max)
        {
            return IsMaxLength("", value, max);
        }

        public Validator IsMaxLength(string name, string value, int max)
        {
            return IsMaxLength(name, value, max, string.Format(MessageContainer.IsMaxLengthMessage, name, max));
        }

        public Validator IsMaxLength(string name, string value, int max, string message)
        {
            // do the check
            if (value.IsMaxLength(max))
            {
                return NoError();

            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsBetweenLength "

        public Validator IsBetweenLength(string value, int min, int max)
        {
            return IsBetweenLength("", value, min, max);
        }

        public Validator IsBetweenLength(string name, string value, int min, int max)
        {
            return IsBetweenLength(name, value, min, max, string.Format(MessageContainer.IsBetweenLengthMessage, name, min, max));
        }

        public Validator IsBetweenLength(string name, string value, int min, int max, string message)
        {
            // do the check
            if (value.IsBetweenLength(min, max))
            {
                return NoError();
            }
            else
            {
                return AddError(name, message);
            }
        }

        #endregion

        #region " IsExactLength "

        public Validator IsExactLength(string value, int exact)
        {
            return IsExactLength("", value, exact);
        }

        public Validator IsExactLength(string name, string value, int exact)
        {
            return IsExactLength(name, value, exact, string.Format(MessageContainer.IsExactLengthMessage, name, exact));
        }

        public Validator IsExactLength(string name, string value, int exact, string message)
        {
            // do the check
            if (!value.IsExactLength(exact))
            {
                return AddError(name, message);
            }
            else
            {
                return NoError();
            }
        }

        #endregion

        #region "EnsureNoHtml"

        public Validator EnsureNoHtml(string fieldName, string value)
        {
            return EnsureNoHtml(fieldName, value, string.Format("The field '{0}' cannot contain HTML tags.", fieldName));
        }

        public Validator EnsureNoHtml(string fieldName, string value, string errorMessage)
        {
            var htmlTagPattern = new Regex("<[^>]+>");
            if (!string.IsNullOrEmpty(value) && htmlTagPattern.IsMatch(value))
            {
                AddError(fieldName, errorMessage);
            }
            return this;
        }

        #endregion
    }
}
