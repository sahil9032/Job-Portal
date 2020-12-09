using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace JobPortal.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthMessageSenderOptions Options { get; } 
        
        public ForgotPasswordModel(UserManager<IdentityUser> userManager, IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            _userManager = userManager;
            Options = optionsAccessor.Value;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Admin", Options.EmailId));
                email.To.Add(new MailboxAddress(Input.Email, Input.Email));
                email.Subject = "Reset Password";
                email.Body = new TextPart(TextFormat.Html) { Text = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>." };

                // send email
                using (var smtp = new SmtpClient())
                {
                    await smtp.ConnectAsync("smtp.sahilbhuva.tech", 587, SecureSocketOptions.None);
                    await smtp.AuthenticateAsync(Options.EmailId, Options.Password);
                    await smtp.SendAsync(email);
                }
                
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
